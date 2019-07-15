using System.Collections.Generic;
using System.Linq;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Common.Models;
using UniversalReports.CN88WinLoss.Common.Services;

namespace UniversalReports.CN88WinLoss.Common.MatchDetailByCode
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }

    public class WinLossServiceImp : WinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public WinLossServiceImp(
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
            var leagueWinLosses = leagues.Select(l => CalculateLeagueWinLoss(l, rawWinLosses))
                                         .OrderBy(l => l.Name);
            var grandTotal = calculationService.CalculateSumWinLoss("Grand Total", rawWinLosses);

            return new WinLossModel
            {
                Leagues = leagueWinLosses.ToList(),
                Total = grandTotal
            };
        }

        private LeagueWinLoss CalculateLeagueWinLoss(string league, IEnumerable<WinLossRaw> rawWinLosses)
        {
            var rawLeagueWinLosses = rawWinLosses.Where(r => r.GroupName == league);
            var matchWinLosses = rawLeagueWinLosses
                .Select(m => calculationService.FromRawWinLossByRowName(m))
                .OrderBy(m => m.Name);
            var total = calculationService.CalculateSumWinLoss(string.Empty, rawLeagueWinLosses);
            return new LeagueWinLoss
            {
                Name = league,
                Matches = matchWinLosses.ToList(),
                Total = total
            };
        }
    }
}