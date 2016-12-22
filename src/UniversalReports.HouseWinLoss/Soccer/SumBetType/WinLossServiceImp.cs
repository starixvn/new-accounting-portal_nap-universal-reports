using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Soccer.SumBetType
{
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

            var betTypeWinLosses = calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var mainTotal = calculationService.CalculateMainSumWinLossSummary("Main Bet Types Total", rawWinLosses);
            var otherTotal = calculationService.CalculateOtherSumWinLossSummary("Other Bet Types Total", rawWinLosses);
            var hedgeTotal = calculationService.CalculateHedgeSumWinLossSummary("Hedge Total", rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLosses);
            var allRMData = calculationService.CalculateRM(rawWinLosses);

            return new WinLossModel
            {
                SiteWinLossSummaries = betTypeWinLosses.ToList(),
                MainTotal = mainTotal,
                OtherTotal = otherTotal,
                GrandTotal = grandTotal,
                HedgeTotal = hedgeTotal,
                RM = allRMData.ToList()
            };
        }
    }
}