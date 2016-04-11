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
                Margin = CalculateMargin(rawWinLoss.RealIncome, rawWinLoss.RealTurnover)
            };
        }

        public decimal CalculateMargin(decimal income, decimal turnover)
        {
            return turnover > 0 ? income / turnover : 0;
        }

        public IEnumerable<LeagueWinLoss> CalculateLeagues(IEnumerable<MatchDetailRawWinLoss> rawWinLoss)
        {
            var groups = rawWinLoss.GroupBy(x => x.LeagueId).Distinct();
            return from @group in groups
                   select CalculateLeague(@group, @group.Key);
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

        public MatchDetailWinLoss CalculateSumWinLoss(IEnumerable<MatchDetailRawWinLoss> rawWinLosses)
        {
            if (!rawWinLosses.Any())
            {
                return new MatchDetailWinLoss();
            }

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
    }
}