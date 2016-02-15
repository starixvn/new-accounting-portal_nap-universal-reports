using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Racing.MatchDetail
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

            var leagues = rawWinLosses.Select(l => l.GroupName).Distinct();
            var leagueWinLosses = leagues.Select(l => CalculateLeagueWinLoss(l, rawWinLosses));
            var grandTotal = _calculationService.CalculateSumWinLoss("Grand Total", rawWinLosses);

            return new WinLossModel
            {
                Leagues = leagueWinLosses.ToList(),
                Total = grandTotal
            };
        }

        private LeagueWinLoss CalculateLeagueWinLoss(string league, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawLeagueWinLosses = rawWinLosses.Where(r => r.GroupName == league);
            var raceWinLosses = rawLeagueWinLosses.Select(m => _calculationService.FromRawWinLossByRowName(m));
            var total = _calculationService.CalculateSumWinLoss("Total", rawLeagueWinLosses);
            return new LeagueWinLoss
            {
                LeagueName = league,
                Races = raceWinLosses.ToList(),
                Total = total
            };
        }
    }
}
