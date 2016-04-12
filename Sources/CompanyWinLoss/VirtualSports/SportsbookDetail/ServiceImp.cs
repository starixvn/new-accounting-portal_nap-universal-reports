using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
{
    public class ServiceImp : Service
    {
        private readonly MatchDetailRawWinLossService rawWinLossService;

        private readonly MatchDetailCalculationService calculationService;

        public ServiceImp(
            MatchDetailRawWinLossService rawWinLossService,
            MatchDetailCalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var matches = calculationService.CalculateMatches(rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLoss(rawWinLosses);

            return new WinLossModel
            {
                Matches = matches.ToList(),
                Total = grandTotal
            };
        }
    }
}