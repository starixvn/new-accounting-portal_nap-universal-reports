using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Soccer.LiveNonLive
{
    public interface SoccerLiveNonLiveWinLossService
    {
        IEnumerable<BasicWinLossModel> Query(WinLossCriteria criteria);
    }

    public class SoccerLiveNonLiveWinLossServiceImp : SoccerLiveNonLiveWinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public SoccerLiveNonLiveWinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public IEnumerable<BasicWinLossModel> Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var majorMinorRawWinLosses = rawWinLosses.Where(r => !r.GroupName.Contains("Live"));

            var majorMinorSiteWinLossSummaries = calculationService.CalculateSiteWinLossSummary(majorMinorRawWinLosses);
            var majorMinorGrandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", majorMinorRawWinLosses);
            var majorMinorAllRMData = calculationService.CalculateRM(rawWinLosses);

            yield return new BasicWinLossModel
            {
                SiteWinLossSummaries = majorMinorSiteWinLossSummaries.ToList(),
                RM = majorMinorAllRMData.ToList(),
                GrandTotal = majorMinorGrandTotal
            };

            var liveNonLiveRawWinLosses = rawWinLosses.Where(r => !r.GroupName.Contains("Bet Types"));

            var liveNonLiveSiteWinLossSummaries = calculationService.CalculateSiteWinLossSummary(liveNonLiveRawWinLosses);
            var liveNonLiveGrandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", liveNonLiveRawWinLosses);
            var liveNonLiveAllRMData = calculationService.CalculateRM(rawWinLosses);

            yield return new BasicWinLossModel
            {
                SiteWinLossSummaries = liveNonLiveSiteWinLossSummaries.ToList(),
                RM = liveNonLiveAllRMData.ToList(),
                GrandTotal = liveNonLiveGrandTotal
            };
        }
    }
}
