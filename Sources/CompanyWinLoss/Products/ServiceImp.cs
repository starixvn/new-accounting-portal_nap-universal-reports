using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ServiceImp : Service
    {
        private readonly RawWinLossService _rawWinLossService;

        private readonly CalculationService _calculationService;

        public ServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this._rawWinLossService = rawWinLossService;
            this._calculationService = calculationService;
        }

        public virtual ProductWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var rawSportsbookProducts = rawWinLosses.Where(r => Constants.NameSportsbook.Contains(r.GroupName));

            var rawNonSportsbookProducts = (from r in rawWinLosses
                                            where !Constants.NameSportsbook.Contains(r.GroupName)
                                            select r).ToList();
            var rawSportsGrandTotal = (from r in rawWinLosses
                                       where !Constants.NamesExclude.Contains(r.GroupName)
                                       select r).ToList();
            return new ProductWinLoss
            {
                GrandTotal = _calculationService.CalculateSumWinLossSummary("Grand Total", rawSportsGrandTotal),
                NoneSportsbookProducts = GetNoneSportbookProducts(rawNonSportsbookProducts),
                SportsbookProducts = GetSportsbookProducts(rawSportsbookProducts)
            };
        }

        public virtual SportsbookWinLoss GetSportsbookProducts(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawProducts = rawWinLosses.Where(r => r.GroupName != "RM").ToList();
            var products = _calculationService.CalculateSiteWinLossSummary(rawProducts);
            var rM = rawWinLosses.Where(r => r.GroupName == "RM").ToList();
            return new SportsbookWinLoss
            {
                Products = products.ToList(),
                RM = CalculateSportsbookDetail(rM)
            };
        }

        public virtual NoneSportsbookWinloss GetNoneSportbookProducts(IEnumerable<RawWinLoss> rawWinLosses)
        {
            return new NoneSportsbookWinloss
            {
                Products = _calculationService.CalculateSiteWinLossSummary(rawWinLosses).ToList(),
                Total = _calculationService.CalculateSumWinLossSummary("Non-Sports Total", rawWinLosses)
            };
        }

        public virtual List<WinLoss> CalculateSportsbookDetail(IEnumerable<RawWinLoss> rawWinLosses)
        {
            return rawWinLosses.Select(r => _calculationService.FromRawWinLossByRowName(r)).ToList();
        }
    }
}