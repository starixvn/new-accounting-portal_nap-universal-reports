using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.SportsbookMatchDetail
{
    internal static class WinLossFactory
    {
        internal static RawWinLoss CreateRawWinLoss(
           string matchCode,
           int homeId,
           int awayId,
           decimal memberWinLoss,
           decimal smaWinLoss,
           decimal commission,
           decimal realIncome,
           decimal realTurnover)
        {
            return new RawWinLoss
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

        internal static WinLoss CreateWinLoss(
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
            return new WinLoss
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
