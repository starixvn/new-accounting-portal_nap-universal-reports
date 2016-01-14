using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

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

        internal static bool AreTwoRawWinLossEqual(RawWinLoss first, RawWinLoss second)
        {
            return first.Product == second.Product &&
                first.Site == second.Site &&
                    first.MemberWinLoss == second.MemberWinLoss &&
                    first.SMAWinLoss == second.SMAWinLoss &&
                    first.Commission == second.Commission &&
                    first.RealIncome == second.RealIncome &&
                    first.VirtualIncome == second.VirtualIncome &&
                    first.RealTurnover == second.RealTurnover &&
                    first.VirtualTurnover == second.VirtualTurnover;
        }

        internal static bool AreTwoWinLossListEqual(List<WinLoss> first, List<WinLoss> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            for (var i = 0; i < first.Count; i++)
            {
                if (!AreTwoWinLossEqual(first[i], second[i]))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool AreTwoProductWinLossListEqual(List<ProductWinLoss> first, List<ProductWinLoss> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            for (var i = 0; i < first.Count; i++)
            {
                if (!AreTwoProductWinLossEqual(first[i], second[i]))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool AreTwoMainWinLossEqual(MainWinLoss first, MainWinLoss second)
        {
            return AreTwoWinLossListEqual(first.SportsbookDetail, second.SportsbookDetail)
                && AreTwoProductWinLossEqual(first.GrandTotal, second.GrandTotal)
                && AreTwoProductWinLossListEqual(first.Products, second.Products);
        }
    }
}
