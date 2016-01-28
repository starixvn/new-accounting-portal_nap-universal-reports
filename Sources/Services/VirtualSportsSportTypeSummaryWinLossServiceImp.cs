using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class VirtualSportsSportTypeSummaryWinLossServiceImp : VirtualSportsSportTypeSummaryWinLossService
    {
        private RawWinLossService _rawWinLossService;

        private CalculationService _calculationService;

        public VirtualSportsSportTypeSummaryWinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public VirtualSportsSportTypeWinLossSummary Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var sports = _calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var grandTotal = _calculationService.CalculateGrandTotal("All Total", rawWinLosses);

            return new VirtualSportsSportTypeWinLossSummary
            {
                Sports = sports.ToList(),
                GrandTotal = grandTotal
            };
        }
    }
}
