using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.NumberGame.MatchDetail
{
    public class ServiceImp : Service
    {
        private readonly RawService _rawWinLossService;

        private readonly CalculationService _calculationService;

        public ServiceImp(
            RawService rawService,
            CalculationService calculationService)
        {
            _rawWinLossService = rawService;
            _calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var leagues = rawWinLosses.Select(l => l.GroupName).Distinct();
            var leagueWinLosses = leagues.Select(l => CalculateLeagueWinLoss(l, rawWinLosses));
            var grandTotal = _calculationService.CalculateSumWinLoss(string.Empty, rawWinLosses);

            return new WinLossModel
            {
                Leagues = leagueWinLosses.ToList(),
                Total = grandTotal
            };
        }

        private LeagueWinLoss CalculateLeagueWinLoss(string league, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawLeagueWinLosses = rawWinLosses.Where(r => r.GroupName == league);
            var matchWinLosses = rawLeagueWinLosses.Select(m => _calculationService.FromRawWinLoss(m));
            return new LeagueWinLoss
            {
                LeagueName = league,
                Matches = matchWinLosses.ToList()
            };
        }
    }
}
