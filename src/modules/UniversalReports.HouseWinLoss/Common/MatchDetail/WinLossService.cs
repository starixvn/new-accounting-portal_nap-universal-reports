using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail
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
            var rm = calculationService.CalculateRM(rawWinLoss).ToList();

            return new WinLossModel
            {
                Leagues = leagues,
                Total = total,
                RM = rm
            };
        }
    }

    public class WinLossService3rdImp : WinLossServiceImp
    {
        public WinLossService3rdImp(RawWinLossService rawWinLossService, Calculation3rdServiceImp calculationService) : base(rawWinLossService, calculationService)
        {
        }
    }
}