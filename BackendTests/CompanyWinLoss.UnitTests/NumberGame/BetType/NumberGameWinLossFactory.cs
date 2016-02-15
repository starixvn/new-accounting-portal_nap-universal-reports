using UniversalReports.CompanyWinLoss.NumberGame.BetType;

namespace UniversalReports.CompanyWinLoss.UnitTests.NumberGame.BetType
{
    internal static class NumberGameWinLossFactory
    {
        internal static RawWinLoss CreateRawWinLoss(
            int groupId,
           string groupName,
           string site,
           bool isLive,
           decimal memberWinLoss,
           decimal smaWinLoss,
           decimal commission,
           decimal realIncome,
           decimal virtualIncome,
           decimal realTurnover,
           decimal virtualTurnover)
        {
            return new RawWinLoss
            {
                GroupId = groupId,
                GroupName = groupName,
                RowName = site,
                IsLive = isLive,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                VirtualIncome = virtualIncome,
                RealTurnover = realTurnover,
                VirtualTurnover = virtualTurnover
            };
        }
    }
}
