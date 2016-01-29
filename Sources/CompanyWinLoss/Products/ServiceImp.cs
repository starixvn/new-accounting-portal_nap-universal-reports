using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ServiceImp : Service
    {
        private readonly RawService _rawWinLossService;

        private readonly CalculationService _calculationService;

        public ServiceImp(
            RawService rawService,
            CalculationService calculationService)
        {
            _rawWinLossService = rawService;
            _calculationService = calculationService;
        }

        public virtual ProductWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var rawSportsbookDetail = rawWinLosses.Where(r => r.GroupName == "Sportsbook Detail");
            var rawProductWinLoss = rawWinLosses.Where(r => r.GroupName != "Sportsbook Detail");

            var sportsbookDetail = CalculateSportsbookDetail(rawSportsbookDetail);
            var productWinLoss = _calculationService.CalculateSiteWinLossSummary(rawProductWinLoss);

            var grandTotal = _calculationService.CalculateSumWinLossSummary("GRAND TOTAL", rawProductWinLoss);

            return new ProductWinLoss
            {
                GrandTotal = grandTotal,
                Products = productWinLoss.ToList(),
                SportsbookDetail = sportsbookDetail
            };
        }

        public virtual List<WinLoss> CalculateSportsbookDetail(IEnumerable<RawWinLoss> rawWinLosses)
        {
            return rawWinLosses.Select(r => _calculationService.FromRawWinLoss(r)).ToList();
        }
    }
}
