using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
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

            var matches = rawWinLosses.Select(l => calculationService.FromRawWinLoss(l));
            var grandTotal = calculationService.CalculateSumWinLoss(rawWinLosses);

            return new WinLossModel
            {
                Matches = matches.ToList(),
                Total = grandTotal
            };
        }
    }
}
