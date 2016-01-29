using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingMatchDetail
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

            var matchWinLosses = rawWinLosses.Select(l => _calculationService.FromRawWinLossByRowName(l));
            var grandTotalWinLoss = _calculationService.CalculateSumWinLoss("Total", rawWinLosses);

            return new WinLossModel
            {
                Matches = matchWinLosses.ToList(),
                Total = grandTotalWinLoss
            };
        }
    }
}
