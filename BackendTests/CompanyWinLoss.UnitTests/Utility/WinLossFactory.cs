using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.UnitTests.Utility
{
    internal class WinLossFactory
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
           decimal realTurnover,
           decimal virtualTurnover)
        {
            return new RawWinLoss
            {
                GroupId = groupId,
                GroupName = groupName,
                RowName = site,
                IsLive = false,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                VirtualIncome = virtualIncome,
                RealTurnover = realTurnover,
                VirtualTurnover = virtualTurnover
            };
        }

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

        internal static WinLoss CreateWinLoss(
            int groupId,
            string groupName,
            decimal memberWinLoss,
            decimal smaWinLoss,
            decimal commission,
            decimal realIncome,
            decimal virtualIncome,
            decimal varianceIncome,
            decimal realTurnover,
            decimal virtualTurnover,
            decimal realMargin,
            decimal virtualMargin)
        {
            return new WinLoss
            {
                GroupName = groupName,
                GroupId = groupId,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                VirtualIncome = virtualIncome,
                RealTurnover = realTurnover,
                VirtualTurnover = virtualTurnover,
                VarianceIncome = varianceIncome,
                RealMargin = realMargin,
                VirtualMargin = virtualMargin
            };
        }
    }
}
