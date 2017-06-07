using Linq.DynamicSum;
using System.Collections.Generic;
using System.Linq;
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
            return new WinLoss
            {
                MatchId = rawWinLoss.MatchId,
                MatchCode = rawWinLoss.MatchCode,
                EventDate = rawWinLoss.EventDate,
                SportType = rawWinLoss.SportType,
                IsNeutral = rawWinLoss.IsNeutral,
                HomeId = rawWinLoss.HomeId,
                AwayId = rawWinLoss.AwayId,
                HomeName = GetHomeName(rawWinLoss.HomeId, rawWinLoss.IsNeutral),
                AwayName = refService.GetTeamName(rawWinLoss.AwayId),
                LeagueId = rawWinLoss.LeagueId,
                LeagueName = refService.GetLeagueName(rawWinLoss.LeagueId),
                Commission = rawWinLoss.Commission,
                MemberWinLoss = rawWinLoss.MemberWinLoss,
                RealIncome = rawWinLoss.RealIncome,
                VirtualIncome = rawWinLoss.VirtualIncome,
                RealTurnover = rawWinLoss.RealTurnover,
                VirtualTurnover = rawWinLoss.VirtualTurnover,
                VarianceIncome = rawWinLoss.VarianceIncome,
                SMAWinLoss = rawWinLoss.SMAWinLoss,
            };
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