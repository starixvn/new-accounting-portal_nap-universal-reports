using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.Services.Models;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
{
    internal class WinLossFactory
    {
        internal static RawWinLoss CreateRawWinLoss(
            string title,
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
                Title = title,
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
            string title,
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
                Title = title,
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
