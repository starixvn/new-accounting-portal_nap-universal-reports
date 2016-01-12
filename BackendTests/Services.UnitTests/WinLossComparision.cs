using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.Services.MainReport;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
{
    internal class WinLossComparision
    {
        internal static bool AreTwoProductWinLossEqual(ProductWinLoss first, ProductWinLoss second)
        {
            return AreTwoWinLossEqual(first.Total, second.Total)
                && AreTwoWinLossEqual(first.Deposit, second.Deposit)
                && AreTwoWinLossEqual(first.Credit, second.Credit);
        }
     
        internal static bool AreTwoWinLossEqual(WinLoss first, WinLoss second)
        {
            return first.Title == second.Title &&
                    first.MemberWinLoss == second.MemberWinLoss &&
                    first.SMAWinLoss == second.SMAWinLoss &&
                    first.Commission == second.Commission &&
                    first.RealIncome == second.RealIncome &&
                    first.VirtualIncome == second.VirtualIncome &&
                    first.RealTurnover == second.RealTurnover &&
                    first.VirtualTurnover == second.VirtualTurnover &&
                    first.VarianceIncome == second.VarianceIncome &&
                    first.RealMargin == second.RealMargin &&
                    first.VirtualMargin == second.VirtualMargin;
        }
    }
}
