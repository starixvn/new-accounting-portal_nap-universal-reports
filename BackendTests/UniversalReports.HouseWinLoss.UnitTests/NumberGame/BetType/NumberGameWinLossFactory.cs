using CommonModels = UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.UnitTests.NumberGame.BetType
{
    internal static class NumberGameWinLossFactory
    {
        internal static CommonModels.RawWinLoss CreateRawWinLoss(
            int groupId,
           string groupName,
           string site,
           bool isLive,
           decimal memberWinLoss,
           decimal smaWinLoss,
           decimal commission,
           decimal realIncome,
           decimal virtualIncome,
           decimal varianceIncome,
           decimal realTurnover,
           decimal virtualTurnover)
        {
            return new CommonModels.RawWinLoss
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
                VarianceIncome = varianceIncome,
                RealTurnover = realTurnover,
                VirtualTurnover = virtualTurnover
            };
        }
    }
}
