using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    public class ServiceImp : Service
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public ServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var liveGroupWinLoss = rawWinLosses.Where(r => r.IsLive);
            var nonLiveGroupWinLoss = rawWinLosses.Where(r => !r.IsLive);

            var live = calculationService.CalculateSiteWinLossSummary(liveGroupWinLoss);
            var nonLive = calculationService.CalculateSiteWinLossSummary(nonLiveGroupWinLoss);
            var liveGrandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", liveGroupWinLoss);
            var noneLiveGrandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", nonLiveGroupWinLoss);

            return new WinLossModel
            {
                Live = live.ToList(),
                NonLive = nonLive.ToList(),
                LiveGrandTotal = liveGrandTotal,
                NonLiveGrandTotal = noneLiveGrandTotal
            };
        }
    }
}