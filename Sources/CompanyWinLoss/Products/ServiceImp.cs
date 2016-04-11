using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ServiceImp : Service
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public ServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public virtual ProductWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);
            var listSportsbook = new SportsbookConstants();
            var rawSportsbookProducts = rawWinLosses.Where(r => listSportsbook.stringName.Contains(r.GroupName));

            var rawNonSportsbookProducts = (from r in rawWinLosses
                                            where !listSportsbook.stringName.Contains(r.GroupName)
                                            select r).ToList();

            var sportsbookProducts = GetSportsbookProducts(rawSportsbookProducts);
            var nonSportsbookProducts = GetNoneSportbookProducts(rawNonSportsbookProducts);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", rawNonSportsbookProducts);

            return new ProductWinLoss
            {
                GrandTotal = grandTotal,
                NoneSportsbookProducts = nonSportsbookProducts,
                SportsbookProducts = sportsbookProducts
            };
        }

        public virtual SportsbookWinLoss GetSportsbookProducts(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawProducts = rawWinLosses.Where(r => r.GroupName != "RM").ToList();
            var products = calculationService.CalculateSiteWinLossSummary(rawProducts);
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
                Products = calculationService.CalculateSiteWinLossSummary(rawWinLosses).ToList(),
                Total = calculationService.CalculateSumWinLossSummary("Non-Sport Total",rawWinLosses)
            };
        }
        public virtual List<WinLoss> CalculateSportsbookDetail(IEnumerable<RawWinLoss> rawWinLosses)
        {
            return rawWinLosses.Select(r => calculationService.FromRawWinLossByRowName(r)).ToList();
        }
    }
}