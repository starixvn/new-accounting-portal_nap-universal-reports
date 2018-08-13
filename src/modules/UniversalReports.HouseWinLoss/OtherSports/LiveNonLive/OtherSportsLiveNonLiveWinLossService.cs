using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.OtherSports.LiveNonLive
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

            var sportTypeRawWinLosses = rawWinLosses.Where(r => !r.GroupName.Contains("Live") && !r.GroupName.Contains("Other Sports"));
            var sportTypeSiteWinLossSummaries = calculationService.CalculateSiteWinLossSummary(sportTypeRawWinLosses);
            var sportTypeGrandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", sportTypeRawWinLosses);
            var sportTypeAllRMData = calculationService.CalculateRM(rawWinLosses);

            yield return new BasicWinLossModel
            {
                SiteWinLossSummaries = sportTypeSiteWinLossSummaries.ToList(),
                RM = sportTypeAllRMData.ToList(),
                GrandTotal = sportTypeGrandTotal
            };

            var liveNonLiveRawWinLosses = rawWinLosses.Where(r => r.GroupName.Contains("Live") && r.GroupName.Contains("Other Sports"));
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
