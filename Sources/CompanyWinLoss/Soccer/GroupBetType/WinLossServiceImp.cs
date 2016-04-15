using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    public class WinLossServiceImp : WinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly BetType.CalculationService calculationService;

        public WinLossServiceImp(
            RawWinLossService rawWinLossService,
            BetType.CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var betTypeWinLosses = calculationService.CalculateSiteWinLossSummaryGroups(rawWinLosses);
            var mainTotal = calculationService.CalculateMainSumWinLossSummary("Main Bet Types Total", rawWinLosses);
            var otherTotal = calculationService.CalculateOtherSumWinLossSummary("Other Bet Types Total", rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("All Total", rawWinLosses);
            var allRMData = calculationService.CalculateRM(rawWinLosses);

            return new WinLossModel
            {
                SiteWinLossSummaries = betTypeWinLosses,
                MainTotal = mainTotal,
                OtherTotal = otherTotal,
                GrandTotal = grandTotal,
                RM = allRMData.ToList()
            };
        }
    }
}
