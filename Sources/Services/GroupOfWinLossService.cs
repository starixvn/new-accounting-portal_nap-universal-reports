using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class GroupOfWinLossService : IGroupOfWinLossService
    {
        private IRawWinLossService _rawWinLossService;

        private ICalculationService _calculationService;

        public GroupOfWinLossService(
            IRawWinLossService rawWinLossService,
            ICalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public GroupOfWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            return CalculateGroupOfWinLoss(rawWinLosses);
        }

        public virtual GroupOfWinLoss CalculateGroupOfWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var winlosses = rawWinLosses.Select(r => _calculationService.FromRawWinLoss(r)).ToList();
            var rawTotal = _calculationService.CalculateSum(rawWinLosses);
            var grandTotal = _calculationService.FromRawWinLoss(rawTotal);
            grandTotal.Title = "Total";

            return new GroupOfWinLoss
            {
                WinLosses = winlosses,
                GrandTotal = grandTotal
            };
        }
    }
}
