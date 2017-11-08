using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail3rd
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }

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

            return new WinLossModel
            {
                Leagues = leagues,
                Total = total,
            };
        }
    }
}
