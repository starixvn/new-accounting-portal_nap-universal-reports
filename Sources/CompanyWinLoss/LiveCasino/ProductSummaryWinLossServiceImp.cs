using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino
{
    public class ProductSummaryWinLossServiceImp : ProductSummaryWinLossService
    {
        private CalculationService _calculationService;
        private RawWinLossService _rawWinLossService;

        public ProductSummaryWinLossServiceImp(RawWinLossService rawWinLossService, CalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public ProductSummaryWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLoss = _rawWinLossService.Query(criteria);
            var products = _calculationService.CalculateSiteWinLossSummary(rawWinLoss).ToList();
            var grandTotal = _calculationService.CalculateGrandTotal("All Total", rawWinLoss);

            return new ProductSummaryWinLoss
            {
                Products = products,
                GrandTotal = grandTotal
            };
        }
    }
}
