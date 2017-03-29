using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Soccer.GroupBetType
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }

    public class WinLossServiceImp : WinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly BaseService.CalculationService calculationService;

        public WinLossServiceImp(
            RawWinLossService rawWinLossService,
            BaseService.CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);
            var nonRMRawWinLosses = rawWinLosses.Where(r => r.GroupName != "RM");

            var betTypeWinLosses = calculationService.CalculateSiteWinLossSummaryGroups(nonRMRawWinLosses);
            var mainTotal = calculationService.CalculateMainSumWinLossSummary("Main Bet Types Total", nonRMRawWinLosses);
            var hedgeTotal = calculationService.CalculateHedgeSumWinLossSummary("Hedge Total", nonRMRawWinLosses);
            var otherTotal = calculationService.CalculateOtherSumWinLossSummary("Other Bet Types Total", nonRMRawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", nonRMRawWinLosses);
            var allRMData = calculationService.CalculateRM(rawWinLosses);

            return new WinLossModel
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