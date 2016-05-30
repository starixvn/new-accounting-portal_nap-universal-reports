using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public class WinLossServiceImp : WinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public WinLossServiceImp(RawWinLossService rawWinLossService, CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLoss = rawWinLossService.Query(criteria);
            var leagues = calculationService.CalculateLeagues(rawWinLoss).ToList();
            var total = calculationService.CalculateSumWinLoss(rawWinLoss);
            var rm = calculationService.CalculateRM(rawWinLoss).ToList();

            return new WinLossModel
            {
                Leagues = leagues,
                Total = total,
                RM = rm
            };
        }
    }
}