using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Common.Services;

namespace UniversalReports.CN88WinLoss.OtherSports.LiveNonLive
{
    public interface OtherSportsLiveNonLiveWinLossService
    {
        IEnumerable<BasicWinLossModel> Query(WinLossCriteria criteria);
    }

    public class OtherSportsLiveNonLiveWinLossServiceImp : OtherSportsLiveNonLiveWinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public OtherSportsLiveNonLiveWinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public IEnumerable<BasicWinLossModel> Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var sportTypeRawWinLosses = rawWinLosses.Where(r => !r.GroupName.Equals("Other Sports Live", StringComparison.CurrentCultureIgnoreCase)
                                                                && !r.GroupName.Equals("Other Sports Non-Live", StringComparison.CurrentCultureIgnoreCase));
            var sportTypeSiteWinLossSummaries = calculationService.CalculateWinLossSummary(sportTypeRawWinLosses);
            var sportTypeGrandTotal = calculationService.CalculateSumWinLoss("Grand Total", sportTypeRawWinLosses);

            yield return new BasicWinLossModel
            {
                WinLosses = sportTypeSiteWinLossSummaries.ToList(),
                GrandTotal = sportTypeGrandTotal
            };

            var liveNonLiveRawWinLosses = rawWinLosses.Where(r => r.GroupName.Equals("Other Sports Live", StringComparison.CurrentCultureIgnoreCase)
                                                                || r.GroupName.Equals("Other Sports Non-Live", StringComparison.CurrentCultureIgnoreCase));
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
