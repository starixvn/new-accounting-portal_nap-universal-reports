using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Linq.DynamicSum;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail
{
    public interface CalculationService
    {
        IEnumerable<LeagueWinLoss> CalculateLeagues(IEnumerable<RawWinLoss> rawWinLoss);

        WinLoss CalculateSumWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        IEnumerable<WinLoss> CalculateRM(IEnumerable<RawWinLoss> rawWinLosses);
    }

    public class CalculationServiceImp : CalculationService
    {
        private readonly RemotingRefService refService;

        public CalculationServiceImp(RemotingRefService refService)
        {
            this.refService = refService;
        }

        public WinLoss FromRawWinLoss(RawWinLoss rawWinLoss)
        {
            var winLoss = Mapper.Map<WinLoss>(rawWinLoss);
            winLoss.HomeName = GetHomeName(rawWinLoss.HomeId, rawWinLoss.IsNeutral);
            winLoss.AwayName = refService.GetTeamName(rawWinLoss.AwayId);
            winLoss.LeagueName = refService.GetLeagueName(rawWinLoss.LeagueId);
            return winLoss;
        }

        private string GetHomeName(int teamId, bool isNeutral)
        {
            return refService.GetTeamName(teamId)
                + (isNeutral ? " (N)" : string.Empty);
        }

        public IEnumerable<LeagueWinLoss> CalculateLeagues(IEnumerable<RawWinLoss> rawWinLoss)
        {
            return rawWinLoss.Where(x => x.LeagueId > 0 && x.MatchId > 0)
                .GroupBy(x => x.LeagueId)
                .Select(x => CalculateLeague(x, x.Key))
                .OrderBy(x => x.LeagueName);
        }

        public LeagueWinLoss CalculateLeague(IEnumerable<RawWinLoss> rawWinLoss, int leagueId)
        {
            var leagueTotal = CalculateSumWinLoss(rawWinLoss);
            leagueTotal.LeagueId = leagueId;
            leagueTotal.LeagueName = refService.GetLeagueName(leagueId);
            var matches = rawWinLoss.Select(FromRawWinLoss)
                .OrderBy(m => m.MatchCode)
                .ThenBy(m => m.HomeName);

            return new LeagueWinLoss
            {
                LeagueName = leagueTotal.LeagueName,
                Matches = matches.ToList(),
                Total = leagueTotal
            };
        }

        public IEnumerable<WinLoss> CalculateMatches(IEnumerable<RawWinLoss> rawWinLoss)
        {
            return rawWinLoss.Where(x => x.LeagueId > 0 && x.MatchId > 0)
                .Select(FromRawWinLoss);
        }

        public WinLoss CalculateSumWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var matchWinLosses = rawWinLosses.Where(r => r.MatchId > 0 && r.LeagueId > 0);
            var sumWinLoss = matchWinLosses.DynamicSum();

            return FromRawWinLoss(sumWinLoss);
        }

        public IEnumerable<WinLoss> CalculateRM(IEnumerable<RawWinLoss> rawWinLosses)
        {
            return rawWinLosses.Where(r => r.MatchId == 0 && r.LeagueId == 0)
                               .Select(FromRawWinLoss);
        }
    }
}