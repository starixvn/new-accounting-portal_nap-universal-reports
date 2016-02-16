using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingMatchDetail
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

            var matchWinLosses = rawWinLosses.Select(l => calculationService.FromRawWinLossByRowName(l));
            var grandTotalWinLoss = calculationService.CalculateSumWinLoss("Total", rawWinLosses);

            return new WinLossModel
            {
                Matches = matchWinLosses.ToList(),
                Total = grandTotalWinLoss
            };
        }
    }
}
