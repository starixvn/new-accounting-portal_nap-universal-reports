using System;
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
                AwayName = refService.GetTeamName(rawWinLoss.AwayId, rawWinLoss.AwayName),
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
                RealMargin = CalculateMargin(rawWinLoss.RealIncome, rawWinLoss.RealTurnover),
                VirtualMargin = CalculateMargin(rawWinLoss.VirtualIncome, rawWinLoss.VirtualTurnover)
            };
        }

        private string GetHomeName(int teamId, bool isNeutral)
        {
            return refService.GetTeamName(teamId, string.Empty)
                + (isNeutral ? " (N)" : string.Empty);
        }

        public decimal CalculateMargin(decimal income, decimal turnover)
        {
            return turnover != 0
                ? Math.Round(income / turnover, 4, MidpointRounding.AwayFromZero)
                : 0;
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
            if (!rawWinLosses.Any())
            {
                return new WinLoss();
            }

            var matchWinLosses = rawWinLosses.Where(r => r.MatchId > 0 && r.LeagueId > 0);
            var sumWinLoss = new RawWinLoss
            {
                AwayId = 0,
                AwayName = string.Empty,
                HomeId = 0,
                HomeName = string.Empty,
                IsNeutral = false,
                LeagueId = 0,
                MatchCode = string.Empty,
                MatchId = 0,
                SMAWinLoss = matchWinLosses.Sum(r => r.SMAWinLoss),
                MemberWinLoss = matchWinLosses.Sum(r => r.MemberWinLoss),
                Commission = matchWinLosses.Sum(r => r.Commission),
                RealIncome = matchWinLosses.Sum(r => r.RealIncome),
                VirtualIncome = matchWinLosses.Sum(r => r.VirtualIncome),
                RealTurnover = matchWinLosses.Sum(r => r.RealTurnover),
                VirtualTurnover = matchWinLosses.Sum(r => r.VirtualTurnover),
                VarianceIncome = matchWinLosses.Sum(r => r.VarianceIncome)
            };

            return FromRawWinLoss(sumWinLoss);
        }

        public IEnumerable<WinLoss> CalculateRM(IEnumerable<RawWinLoss> rawWinLosses)
        {
            return rawWinLosses.Where(r => r.MatchId == 0 && r.LeagueId == 0)
                               .Select(FromRawWinLoss);
        }
    }
}