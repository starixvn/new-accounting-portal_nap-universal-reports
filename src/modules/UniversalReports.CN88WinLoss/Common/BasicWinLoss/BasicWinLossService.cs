using System.Linq;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Common.Services;

namespace UniversalReports.CN88WinLoss.Common.BasicWinLoss
{
    public interface BasicWinLossService
    {
        BasicWinLossModel Query(WinLossCriteria criteria);
    }

    public class BasicWinLossServiceImp : BasicWinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public BasicWinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public BasicWinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var siteWinLossSummaries = calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLosses);
            var allRMData = calculationService.CalculateRM(rawWinLosses);

            return new BasicWinLossModel
            {
                SiteWinLossSummaries = siteWinLossSummaries.ToList(),
                RM = allRMData.ToList(),
                GrandTotal = grandTotal
            };
        }
    }
}