using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailServices
{
    public class MatchDetailCalculationServiceImp : MatchDetailCalculationService
    {
        private readonly RemotingRefService refService;

        public MatchDetailCalculationServiceImp(RemotingRefService refService)
        {
            this.refService = refService;
        }

        public MatchDetailWinLoss FromRawWinLoss(MatchDetailRawWinLoss rawWinLoss)
        {
            return new MatchDetailWinLoss
            {
                MatchId = rawWinLoss.MatchId,
                MatchCode = rawWinLoss.MatchCode,
                IsNeutral = rawWinLoss.IsNeutral,
                HomeId = rawWinLoss.HomeId,
                AwayId = rawWinLoss.AwayId,
                HomeName = refService.GetTeamName(rawWinLoss.HomeId, rawWinLoss.HomeName),
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
                VirtualMargin = CalculateMargin(rawWinLoss.VirtualIncome, rawWinLoss.VirtualTurnover),
            };
        }

        public decimal CalculateMargin(decimal income, decimal turnover)
        {
            return turnover > 0 ? income / turnover : 0;
        }

        public IEnumerable<LeagueWinLoss> CalculateLeagues(IEnumerable<MatchDetailRawWinLoss> rawWinLoss)
        {
            return rawWinLoss.Where(x => x.LeagueId > 0 && x.MatchId > 0)
                .GroupBy(x => x.LeagueId)
                .Select(x => CalculateLeague(x, x.Key));
        }

        public LeagueWinLoss CalculateLeague(IEnumerable<MatchDetailRawWinLoss> rawWinLoss, int leagueId)
        {
            var leagueTotal = CalculateSumWinLoss(rawWinLoss);
            leagueTotal.LeagueId = leagueId;
            leagueTotal.LeagueName = refService.GetLeagueName(leagueId);
            var matches = rawWinLoss.Select(r => FromRawWinLoss(r));

            return new LeagueWinLoss
            {
                LeagueName = leagueTotal.LeagueName,
                Matches = matches.ToList(),
                Total = leagueTotal
            };
        }

        public IEnumerable<MatchDetailWinLoss> CalculateMatches(IEnumerable<MatchDetailRawWinLoss> rawWinLoss)
        {
            return rawWinLoss.Where(x => x.LeagueId > 0 && x.MatchId > 0)
                .Select(x => FromRawWinLoss(x));
        }

        public MatchDetailWinLoss CalculateSumWinLoss(IEnumerable<MatchDetailRawWinLoss> rawWinLosses)
        {
            if (!rawWinLosses.Any())
            {
                return new MatchDetailWinLoss();
            }

            rawWinLosses = rawWinLosses.Where(r => r.MatchId > 0 && r.LeagueId > 0);
            var sumWinLoss = new MatchDetailRawWinLoss
            {
                AwayId = 0,
                AwayName = string.Empty,
                HomeId = 0,
                HomeName = string.Empty,
                IsNeutral = false,
                LeagueId = 0,
                MatchCode = string.Empty,
                MatchId = 0,
                SMAWinLoss = rawWinLosses.Sum(r => r.SMAWinLoss),
                MemberWinLoss = rawWinLosses.Sum(r => r.MemberWinLoss),
                Commission = rawWinLosses.Sum(r => r.Commission),
                RealIncome = rawWinLosses.Sum(r => r.RealIncome),
                VirtualIncome = rawWinLosses.Sum(r => r.VirtualIncome),
                RealTurnover = rawWinLosses.Sum(r => r.RealTurnover),
                VirtualTurnover = rawWinLosses.Sum(r => r.VirtualTurnover),
                VarianceIncome = rawWinLosses.Sum(r => r.VarianceIncome)
            };

            return FromRawWinLoss(sumWinLoss);
        }

        public IEnumerable<MatchDetailWinLoss> CalculateRM(IEnumerable<MatchDetailRawWinLoss> rawWinLosses)
        {
            return rawWinLosses.Where(r => r.MatchId == 0 && r.LeagueId == 0)
                               .Select(r => FromRawWinLoss(r));
        }
    }
}