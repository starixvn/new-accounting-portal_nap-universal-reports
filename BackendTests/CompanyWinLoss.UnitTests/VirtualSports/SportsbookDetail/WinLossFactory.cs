using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.SportsbookDetail
{
    internal static class WinLossFactory
    {
        internal static MatchDetailRawWinLoss CreateRawWinLoss(
           string matchCode,
           int homeId,
           int awayId,
           decimal memberWinLoss,
           decimal smaWinLoss,
           decimal commission,
           decimal realIncome,
           decimal realTurnover)
        {
            return new MatchDetailRawWinLoss
            {
                MatchCode = matchCode,
                HomeId = homeId,
                AwayId = awayId,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                RealTurnover = realTurnover
            };
        }

        internal static MatchDetailWinLoss CreateWinLoss(
            string matchCode,
            string homeName,
            string awayName,
            decimal memberWinLoss,
            decimal smaWinLoss,
            decimal commission,
            decimal realIncome,
            decimal realTurnover,
            decimal margin)
        {
            return new MatchDetailWinLoss
            {
                MatchCode = matchCode,
                HomeName = homeName,
                AwayName = awayName,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                RealTurnover = realTurnover,
                Margin = margin
            };
        }
    }
}
