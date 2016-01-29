using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.VirtualSports.Summary
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

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var sports = _calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var grandTotal = _calculationService.CalculateSumWinLossSummary("All Total", rawWinLosses);

            return new WinLossModel
            {
                Sports = sports.ToList(),
                GrandTotal = grandTotal
            };
        }
    }
}
