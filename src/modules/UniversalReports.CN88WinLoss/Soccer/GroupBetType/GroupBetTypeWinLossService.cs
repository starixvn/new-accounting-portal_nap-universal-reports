using System.Linq;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Common.Services;

namespace UniversalReports.CN88WinLoss.Soccer.GroupBetType
{
    public interface GroupBetTypeWinLossService
    {
        GroupBetTypeWinLossModel Query(WinLossCriteria criteria);
    }

    public class GroupBetTypeWinLossServiceImp : GroupBetTypeWinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly BaseService.BaseCalculationService calculationService;

        public GroupBetTypeWinLossServiceImp(
            RawWinLossService rawWinLossService,
            BaseService.BaseCalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public GroupBetTypeWinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);
            var nonRMRawWinLosses = rawWinLosses.Where(r => r.GroupName != "RM");

            var betTypeWinLosses = calculationService.CalculateSiteWinLossSummaryGroups(nonRMRawWinLosses);
            var mainTotal = calculationService.CalculateMainSumWinLossSummary("Main Bet Types Total", nonRMRawWinLosses);
            var hedgeTotal = calculationService.CalculateHedgeSumWinLossSummary("Hedge Total", nonRMRawWinLosses);
            var otherTotal = calculationService.CalculateOtherSumWinLossSummary("Other Bet Types Total", nonRMRawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", nonRMRawWinLosses);
            var allRMData = calculationService.CalculateRM(rawWinLosses);

            return new GroupBetTypeWinLossModel
            {
                SiteWinLossSummaries = betTypeWinLosses,
                MainTotal = mainTotal,
                OtherTotal = otherTotal,
                HedgeTotal = hedgeTotal,
                GrandTotal = grandTotal,
                RM = allRMData.ToList()
            };
        }
    }
}