using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class ThirdPartyProductServiceImp : ThirdPartyProductService
    {
        private RawWinLossService _rawService;
        private CalculationService _calculationService;

        public ThirdPartyProductServiceImp(RawWinLossService rawService, CalculationService calculationService)
        {
            _rawService = rawService;
            _calculationService = calculationService;
        }

        public ThirdPartyProductWinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLoss = _rawService.Query(criteria);
            var products = _calculationService.CalculateSiteWinLossSummary(rawWinLoss).ToList();
            var grandTotal = _calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLoss);

            return new ThirdPartyProductWinLossModel
            {
                Products = products,
                GrandTotal = grandTotal
            };
        }
    }
}