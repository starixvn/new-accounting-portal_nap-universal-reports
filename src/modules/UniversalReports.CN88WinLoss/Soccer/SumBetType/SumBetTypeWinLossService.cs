using System.Linq;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Common.Services;

namespace UniversalReports.CN88WinLoss.Soccer.SumBetType
{
    public interface SumBetTypeWinLossService
    {
        SumBetTypeWinLossModel Query(WinLossCriteria criteria);
    }

    public class SumBetTypeWinLossServiceImp : SumBetTypeWinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly BaseService.BaseCalculationService calculationService;

        public SumBetTypeWinLossServiceImp(
            RawWinLossService rawWinLossService,
            BaseService.BaseCalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public SumBetTypeWinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var betTypeWinLosses = calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var mainTotal = calculationService.CalculateMainSumWinLossSummary("Main Bet Types Total", rawWinLosses);
            var otherTotal = calculationService.CalculateOtherSumWinLossSummary("Other Bet Types Total", rawWinLosses);
            var hedgeTotal = calculationService.CalculateHedgeSumWinLossSummary("Hedge Total", rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLosses);
            var allRMData = calculationService.CalculateRM(rawWinLosses);

            return new SumBetTypeWinLossModel
            {
                SiteWinLossSummaries = betTypeWinLosses.ToList(),
                MainTotal = mainTotal,
                OtherTotal = otherTotal,
                HedgeTotal = hedgeTotal,
                GrandTotal = grandTotal,
                RM = allRMData.ToList()
            };
        }
    }
}