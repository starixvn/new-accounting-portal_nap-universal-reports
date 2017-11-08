using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Linq.DynamicSum;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail3rd
{
    public interface CalculationService
    {
        IEnumerable<LeagueWinLoss> CalculateLeagues(IEnumerable<RawWinLoss> rawWinLoss);

        WinLoss CalculateSumWinLoss(IEnumerable<RawWinLoss> rawWinLosses);
    }

    public class CalculationServiceImp : CalculationService
    {
        private readonly RemotingRef3rdService refService;

        public CalculationServiceImp(RemotingRef3rdService refService)
        {
            this.refService = refService;
        }

        public WinLoss FromRawWinLoss(RawWinLoss rawWinLoss)
        {
            var winLoss = Mapper.Map<WinLoss>(rawWinLoss);
            winLoss.HomeName = refService.Get3rdTeamName(rawWinLoss.HomeId);
            winLoss.AwayName = refService.Get3rdTeamName(rawWinLoss.AwayId);
            return winLoss;
        }

        public IEnumerable<LeagueWinLoss> CalculateLeagues(IEnumerable<RawWinLoss> rawWinLoss)
        {
            return rawWinLoss.GroupBy(x => x.League)
                .Select(x => CalculateLeague(x, x.Key))
                .OrderBy(x => x.League);
        }

        public LeagueWinLoss CalculateLeague(IEnumerable<RawWinLoss> rawWinLoss, string league)
        {
            var leagueTotal = CalculateSumWinLoss(rawWinLoss);
            leagueTotal.League = league;
            var matches = rawWinLoss.Select(FromRawWinLoss)
                .OrderBy(m => m.MatchCode)
                .ThenBy(m => m.HomeName);

            return new LeagueWinLoss
            {
                League = league,
                Matches = matches.ToList(),
                Total = leagueTotal
            };
        }

        public WinLoss CalculateSumWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var sumWinLoss = rawWinLosses.DynamicSum();

            return FromRawWinLoss(sumWinLoss);
        }
    }
}
