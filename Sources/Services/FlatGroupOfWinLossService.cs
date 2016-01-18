using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class FlatGroupOfWinLossService : IFlatGroupOfWinLossService
    {
        private IRawWinLossService _rawWinLossService;

        private ICalculationService _calculationService;

        public FlatGroupOfWinLossService(
            IRawWinLossService rawWinLossService,
            ICalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public FlatGroupOfWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var winlosses = rawWinLosses.Select(r => _calculationService.FromRawWinLoss(r)).ToList();
            var grandTotal = _calculationService.CalculateTotal("Total", rawWinLosses);

            return new FlatGroupOfWinLoss
            {
                WinLosses = winlosses,
                GrandTotal = grandTotal
            };
        }
    }
}
