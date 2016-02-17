using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct
{
    public class ServiceImp : Service
    {
        private RawWinLossService _rawService;
        private CalculationService _calculationService;

        public ServiceImp(RawWinLossService rawService, CalculationService calculationService)
        {
            _rawService = rawService;
            _calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLoss = _rawService.Query(criteria);
            var products = _calculationService.CalculateSiteWinLossSummary(rawWinLoss).ToList();
            var grandTotal = _calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLoss);

            return new WinLossModel
            {
                Products = products,
                GrandTotal = grandTotal
            };
        }
    }
}
