using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.UnitTests.TestUtility
{
    internal class WinLossComparision
    {
        internal static bool AreTwoSiteWinLossSummaryEqual(SiteWinLossSummary first, SiteWinLossSummary second)
        {
            return AreTwoWinLossEqual(first.Total, second.Total)
                && AreTwoWinLossEqual(first.Deposit, second.Deposit)
                && AreTwoWinLossEqual(first.Credit, second.Credit);
        }

        internal static bool AreTwoWinLossEqual(WinLoss first, WinLoss second)
        {
            return first.Id == second.Id &&
                    first.Name == second.Name &&
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
            return first.GroupId == second.GroupId &&
                first.GroupName == second.GroupName &&
                first.RowName == second.RowName &&
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

            return !first.Where((t, i) => !AreTwoWinLossEqual(t, second[i])).Any();
        }

        internal static bool AreTwoSiteWinLossSummaryListEqual(List<SiteWinLossSummary> first, List<SiteWinLossSummary> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            return !first.Where((t, i) => !AreTwoSiteWinLossSummaryEqual(t, second[i])).Any();
        }

        internal static bool AreTwoProductWinLossEqual(ProductWinLoss first, ProductWinLoss second)
        {
            return AreTwoWinLossListEqual(first.SportsbookDetail, second.SportsbookDetail)
                && AreTwoSiteWinLossSummaryEqual(first.GrandTotal, second.GrandTotal)
                && AreTwoSiteWinLossSummaryListEqual(first.Products, second.Products);
        }

        internal static bool AreTwoSiteWinLossEqual(SiteWinLossModel first, SiteWinLossModel second)
        {
            return AreTwoWinLossListEqual(first.Sites, second.Sites)
                && AreTwoWinLossEqual(first.Total, second.Total);
        }
    }
}
