using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Common.Services;

namespace UniversalReports.CN88WinLoss.Soccer.LiveNonLive
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

            var majorMinorRawWinLosses = rawWinLosses.Where(r => r.GroupName.Equals("Soccer-Major Bet Types", StringComparison.CurrentCultureIgnoreCase)
                                                                || r.GroupName.Equals("Soccer-Minor Bet Types", StringComparison.CurrentCultureIgnoreCase));

            var majorMinorSiteWinLossSummaries = calculationService.CalculateWinLossSummary(majorMinorRawWinLosses);
            var majorMinorGrandTotal = calculationService.CalculateSumWinLoss("Grand Total", majorMinorRawWinLosses);

            yield return new BasicWinLossModel
            {
                WinLosses = majorMinorSiteWinLossSummaries.ToList(),
                GrandTotal = majorMinorGrandTotal
            };

            var liveNonLiveRawWinLosses = rawWinLosses.Where(r => r.GroupName.Equals("Soccer Live", StringComparison.CurrentCultureIgnoreCase)
                                                                || r.GroupName.Equals("Soccer Non-Live", StringComparison.CurrentCultureIgnoreCase));

            var liveNonLiveSiteWinLossSummaries = calculationService.CalculateWinLossSummary(liveNonLiveRawWinLosses);
            var liveNonLiveGrandTotal = calculationService.CalculateSumWinLoss("Grand Total", liveNonLiveRawWinLosses);

            yield return new BasicWinLossModel
            {
                WinLosses = liveNonLiveSiteWinLossSummaries.ToList(),
                GrandTotal = liveNonLiveGrandTotal
            };
        }
    }
}
