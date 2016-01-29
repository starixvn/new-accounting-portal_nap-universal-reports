using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail
{
    public class ServiceImp : Service
    {
        private readonly RawService _rawService;

        private readonly CalculationService _calculationService;

        public ServiceImp(
            RawService rawService,
            CalculationService calculationService)
        {
            _rawService = rawService;
            _calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawService.Query(criteria);

            var matches = rawWinLosses.Select(l => _calculationService.FromRawWinLoss(l));
            var grandTotal = _calculationService.CalculateSumWinLoss(rawWinLosses);

            return new WinLossModel
            {
                Matches = matches.ToList(),
                Total = grandTotal
            };
        }
    }
}
