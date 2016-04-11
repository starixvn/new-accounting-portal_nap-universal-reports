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
                Margin = CalculateMargin(rawWinLoss.RealTurnover, rawWinLoss.RealIncome)
            };
        }

        public decimal CalculateMargin(decimal turnover, decimal income)
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
            var rawWinLossTotal = CalculateSumWinLoss(rawWinLoss);
            var matches = from item in rawWinLoss
                          select FromRawWinLoss(item);

            return new LeagueWinLoss
            {
                LeagueName = refService.GetLeagueName(leagueId),
                Matches = matches.ToList(),
                Total = rawWinLossTotal
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