using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class ServiceImp : Service
    {
        private MatchDetailRawWinLossService rawWinLossService;

        private MatchDetailCalculationService calculationService;

        public ServiceImp(MatchDetailRawWinLossService rawWinLossService, MatchDetailCalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLoss = rawWinLossService.Query(criteria);
            var arenas = calculationService.CalculateLeagues(rawWinLoss).ToList();
            var total = calculationService.CalculateSumWinLoss(rawWinLoss);

            return new WinLossModel
            {
                Arenas = arenas,
                Total = total
            };
        }
    }
}