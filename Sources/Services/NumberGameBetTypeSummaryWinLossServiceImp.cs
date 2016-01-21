using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class NumberGameBetTypeSummaryWinLossServiceImp : NumberGameBetTypeSummaryWinLossService
    {
        private RawWinLossService _rawWinLossService;

        private CalculationService _calculationService;

        public NumberGameBetTypeSummaryWinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public NumberGameBetTypeWinLossSummary Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var liveGroupWinLoss = rawWinLosses.Where(r => r.IsLive);
            var nonLiveGroupWinLoss = rawWinLosses.Where(r => !r.IsLive);

            var live = _calculationService.CalculateSiteWinLossSummary(liveGroupWinLoss);
            var nonLive = _calculationService.CalculateSiteWinLossSummary(nonLiveGroupWinLoss);
            var liveGrandTotal = _calculationService.CalculateGrandTotal("All Total", liveGroupWinLoss);
            var noneLiveGrandTotal = _calculationService.CalculateGrandTotal("All Total", nonLiveGroupWinLoss);

            return new NumberGameBetTypeWinLossSummary
            {
                Live = live.ToList(),
                NonLive = nonLive.ToList(),
                LiveGrandTotal = liveGrandTotal,
                NonLiveGrandTotal = noneLiveGrandTotal
            };
        }
    }
}
