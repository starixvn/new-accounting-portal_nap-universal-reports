using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.CashOut.LiveNonLive
{
    public interface CashOutLiveNonLiveWinLossService
    {
        IEnumerable<BasicWinLossModel> Query(WinLossCriteria criteria);
    }

    public class CashOutLiveNonLiveWinLossServiceImp : CashOutLiveNonLiveWinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public CashOutLiveNonLiveWinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public IEnumerable<BasicWinLossModel> Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var sportTypeRawWinLosses = rawWinLosses.Where(r => !r.GroupName.Contains("Live")
                                                                && !r.GroupName.Contains("Non-Live"));
            var sportTypeSiteWinLossSummaries = calculationService.CalculateSiteWinLossSummary(sportTypeRawWinLosses);
            var sportTypeGrandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", sportTypeRawWinLosses);

            yield return new BasicWinLossModel
            {
                SiteWinLossSummaries = sportTypeSiteWinLossSummaries.ToList(),
                GrandTotal = sportTypeGrandTotal
            };

            var liveNonLiveRawWinLosses = rawWinLosses.Where(r => r.GroupName.Contains("Live")
                                                                || r.GroupName.Contains("Non-Live"));
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
