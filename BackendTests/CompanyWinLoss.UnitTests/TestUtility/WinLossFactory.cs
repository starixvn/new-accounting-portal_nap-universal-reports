using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.UnitTests.TestUtility
{
    internal static class WinLossFactory
    {
        internal static RawWinLoss CreateRawWinLoss(
            int groupId,
           string groupName,
           string site,
           decimal memberWinLoss,
           decimal smaWinLoss,
           decimal commission,
           decimal realIncome,
           decimal virtualIncome,
           decimal varianceIncome,
           decimal extraPT,
           decimal afterExtraPT,
           decimal realTurnover,
           decimal virtualTurnover)
        {
            return new RawWinLoss
            {
                GroupId = groupId,
                GroupName = groupName,
                RowName = site,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                VirtualIncome = virtualIncome,
                VarianceIncome = varianceIncome,
                ExtraPT = extraPT,
                AfterExtraPT = afterExtraPT,
                RealTurnover = realTurnover,
                VirtualTurnover = virtualTurnover
            };
        }

        internal static WinLoss CreateWinLoss(
            int id,
            string name,
            decimal memberWinLoss,
            decimal smaWinLoss,
            decimal commission,
            decimal realIncome,
            decimal virtualIncome,
            decimal varianceIncome,
            decimal extraPT,
            decimal afterExtraPT,
            decimal realTurnover,
            decimal virtualTurnover,
            decimal realMargin,
            decimal virtualMargin)
        {
            return new WinLoss
            {
                Name = name,
                Id = id,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                VirtualIncome = virtualIncome,
                RealTurnover = realTurnover,
                VirtualTurnover = virtualTurnover,
                VarianceIncome = varianceIncome,
                ExtraPT = extraPT,
                AfterExtraPT = afterExtraPT,
                RealMargin = realMargin,
                VirtualMargin = virtualMargin
            };
        }
    }
}
