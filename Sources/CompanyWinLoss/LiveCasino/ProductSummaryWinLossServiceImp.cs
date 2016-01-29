using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino
{
    public class ProductSummaryWinLossServiceImp : ProductSummaryWinLossService
    {
        private CalculationService _calculationService;
        private RawService _rawService;

        public ProductSummaryWinLossServiceImp(RawService rawService, CalculationService calculationService)
        {
            _rawService = rawService;
            _calculationService = calculationService;
        }

        public ProductSummaryWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLoss = _rawService.Query(criteria);
            var products = _calculationService.CalculateSiteWinLossSummary(rawWinLoss).ToList();
            var grandTotal = _calculationService.CalculateSumWinLossSummary("All Total", rawWinLoss);

            return new ProductSummaryWinLoss
            {
                Products = products,
                GrandTotal = grandTotal
            };
        }
    }
}
