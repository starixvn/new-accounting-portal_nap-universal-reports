using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class ServiceImp
    {
        private RawWinLossService rawWinLossService;
        private CalculationService calculationService;

        public ServiceImp(RawWinLossService rawWinLossService, CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLoss = rawWinLossService.Query(criteria);
            var arenas = calculationService.Arenas(rawWinLoss).ToList();
            var totalRawWinLoss = calculationService.CalculationSum(rawWinLoss);
            var total = calculationService.FromRawWinLoss(totalRawWinLoss);

            return new WinLossModel
            {
                Arenas = arenas,
                Total = total
            };
        }
    }
}
