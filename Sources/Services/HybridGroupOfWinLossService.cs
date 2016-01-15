using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class HybridGroupOfWinLossService : IHybridGroupOfWinLossService
    {
        private IRawWinLossService _rawWinLossService;

        private ICalculationService _calculationService;

        public HybridGroupOfWinLossService(
            IRawWinLossService rawWinLossService,
            ICalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public HybridGroupOfWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var winlosses = CalculateGroupOfWinLoss(rawWinLosses).ToList();
            var rawTotal = _calculationService.CalculateSum(rawWinLosses);
            var grandTotal = _calculationService.FromRawWinLoss(rawTotal);
            grandTotal.Title = "Total";

            return new HybridGroupOfWinLoss
            {
                GrandTotal = grandTotal,
                WinLosses = winlosses
            };
        }

        private IEnumerable<GroupOfWinLoss> CalculateGroupOfWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var groups = rawWinLosses.Select(r => r.Group).Distinct().ToArray();
            foreach (var group in groups)
            {
                var rawGroupWinLoss = rawWinLosses.Where(r => r.Group == group);
                var groupWinLoss = rawGroupWinLoss.Select(r => _calculationService.FromRawWinLoss(r))
                                                  .ToList();
                yield return new GroupOfWinLoss
                {
                    Name = group,
                    WinLosses = groupWinLoss
                };
            }
        }
    }
}
