using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Common.BasicWinLoss
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