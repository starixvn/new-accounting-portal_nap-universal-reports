using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Racing.MatchDetail
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

            var leagues = rawWinLosses.Select(l => l.GroupName).Distinct();
            var leagueWinLosses = leagues.Select(l => CalculateLeagueWinLoss(l, rawWinLosses));
            var grandTotal = calculationService.CalculateSumWinLoss("Grand Total", rawWinLosses);

            return new WinLossModel
            {
                Leagues = leagueWinLosses.ToList(),
                Total = grandTotal
            };
        }

        private LeagueWinLoss CalculateLeagueWinLoss(string league, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawLeagueWinLosses = rawWinLosses.Where(r => r.GroupName == league);
            var raceWinLosses = rawLeagueWinLosses.Select(m => calculationService.FromRawWinLossByRowName(m));
            var total = calculationService.CalculateSumWinLoss("Total", rawLeagueWinLosses);
            return new LeagueWinLoss
            {
                LeagueName = league,
                Races = raceWinLosses.ToList(),
                Total = total
            };
        }
    }
}
