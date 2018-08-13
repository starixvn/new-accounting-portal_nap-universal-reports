using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.MetricGaming.LiveNonLive
{
    public interface MetricGamingLiveNonLiveWinLossService
    {
        IEnumerable<BasicWinLossModel> Query(WinLossCriteria criteria);
    }

    public class MetricGamingLiveNonLiveWinLossServiceImp : MetricGamingLiveNonLiveWinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public MetricGamingLiveNonLiveWinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public IEnumerable<BasicWinLossModel> Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var betTypeRawWinLosses = rawWinLosses.Where(r => !r.GroupName.Contains("Live") && !r.GroupName.Contains("Metric Gaming"));
            var betTypeSiteWinLossSummaries = calculationService.CalculateSiteWinLossSummary(betTypeRawWinLosses);
            var betTypeGrandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", betTypeRawWinLosses);

            yield return new BasicWinLossModel
            {
                SiteWinLossSummaries = betTypeSiteWinLossSummaries.ToList(),
                GrandTotal = betTypeGrandTotal
            };

            var liveNonLiveRawWinLosses = rawWinLosses.Where(r => r.GroupName.Contains("Live") && r.GroupName.Contains("Metric Gaming"));
            var liveNonLiveSiteWinLossSummaries = calculationService.CalculateSiteWinLossSummary(liveNonLiveRawWinLosses);
            var liveNonLiveGrandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", liveNonLiveRawWinLosses);

            yield return new BasicWinLossModel
            {
                SiteWinLossSummaries = liveNonLiveSiteWinLossSummaries.ToList(),
                GrandTotal = liveNonLiveGrandTotal
            };
        }
    }
}
