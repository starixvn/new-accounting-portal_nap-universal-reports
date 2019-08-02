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

            var winlosses = calculationService.CalculateWinLossSummary(rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLoss("Grand Total", rawWinLosses);

            return new BasicWinLossModel
            {
                WinLosses = winlosses.ToList(),
                GrandTotal = grandTotal
            };
        }
    }
}