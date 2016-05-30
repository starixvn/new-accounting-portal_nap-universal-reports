using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.MatchDetail;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetail
{
    internal static class WinLossFactory
    {
        internal static RawWinLoss CreateRawWinLoss(
            int matchId,
           int teamId,
           int leagueId,
           decimal winloss,
           decimal commission,
           decimal income,
           decimal turnover)
        {
            return new RawWinLoss
            {
                MatchId = matchId,
                MatchCode = string.Empty,
                LeagueId = leagueId,
                HomeId = teamId,
                AwayId = teamId,
                IsNeutral = false,
                HomeName = string.Empty,
                AwayName = string.Empty,
                MemberWinLoss = winloss,
                SMAWinLoss = winloss,
                Commission = commission,
                RealIncome = income,
                VirtualIncome = income,
                RealTurnover = turnover,
                VirtualTurnover = turnover,
                VarianceIncome = 0
            };
        }

        internal static WinLoss CreateWinLoss(
           int matchId,
           int teamId,
           int leagueId,
           decimal winloss,
           decimal commission,
           decimal income,
           decimal turnover,
           decimal margin)
        {
            return new WinLoss
            {
                MatchId = matchId,
                MatchCode = string.Empty,
                LeagueId = leagueId,
                HomeId = teamId,
                AwayId = teamId,
                IsNeutral = false,
                HomeName = string.Empty,
                AwayName = string.Empty,
                MemberWinLoss = winloss,
                SMAWinLoss = winloss,
                Commission = commission,
                RealIncome = income,
                VirtualIncome = income,
                RealTurnover = turnover,
                VirtualTurnover = turnover,
                VarianceIncome = 0,
                LeagueName = string.Empty,
                RealMargin = margin,
                VirtualMargin = margin
            };
        }

        internal static List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var match1 = CreateRawWinLoss(1, 1, 1, 100, 10, 200, 400);
            var match2 = CreateRawWinLoss(2, 2, 1, 200, 20, 400, 800);
            var match3 = CreateRawWinLoss(3, 3, 1, 300, 30, 600, 1200);
            var match4 = CreateRawWinLoss(4, 4, 1, 400, 40, 800, 1600);
            var matchRM = CreateRawWinLoss(0, 0, 0, 100, 10, 200, 400);

            return new List<RawWinLoss> { match1, match2, match3, match4, matchRM };
        }
    }
}
