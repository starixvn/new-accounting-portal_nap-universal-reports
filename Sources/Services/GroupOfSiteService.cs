using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class GroupOfSiteService : IGroupOfSiteService
    {
        private IRawWinLossService _rawWinLossService;

        private ICalculationService _calculationService;

        public GroupOfSiteService(
            IRawWinLossService rawWinLossService,
            ICalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public GroupOfSiteWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            return CalculateGroupSiteWinLoss(rawWinLosses);
        }

        public virtual GroupOfSiteWinLoss CalculateGroupSiteWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var liveGroupWinLoss = rawWinLosses.Where(r => r.IsLive);
            var nonLiveGroupWinLoss = rawWinLosses.Where(r => !r.IsLive);

            var live = _calculationService.CalculateGroupWinLoss(liveGroupWinLoss);
            var nonLive = _calculationService.CalculateGroupWinLoss(nonLiveGroupWinLoss);
            var liveGrandTotal = _calculationService.CalculateGrandTotal(liveGroupWinLoss);
            var noneLiveGrandTotal = _calculationService.CalculateGrandTotal(nonLiveGroupWinLoss);

            return new GroupOfSiteWinLoss
            {
                Live = live.ToList(),
                NonLive = nonLive.ToList(),
                LiveGrandTotal = liveGrandTotal,
                NonLiveGrandTotal = noneLiveGrandTotal
            };
        }
    }
}
