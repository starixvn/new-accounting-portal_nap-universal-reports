using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.NumberGame.Summary
{
    public class ServiceImp : Service
    {
        private readonly RawService _rawWinLossService;

        private readonly CalculationService _calculationService;

        public ServiceImp(
            RawService rawService,
            CalculationService calculationService)
        {
            _rawWinLossService = rawService;
            _calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var liveGroupWinLoss = rawWinLosses.Where(r => r.IsLive);
            var nonLiveGroupWinLoss = rawWinLosses.Where(r => !r.IsLive);

            var live = _calculationService.CalculateSiteWinLossSummary(liveGroupWinLoss);
            var nonLive = _calculationService.CalculateSiteWinLossSummary(nonLiveGroupWinLoss);
            var liveGrandTotal = _calculationService.CalculateSumWinLossSummary("All Total", liveGroupWinLoss);
            var noneLiveGrandTotal = _calculationService.CalculateSumWinLossSummary("All Total", nonLiveGroupWinLoss);

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
