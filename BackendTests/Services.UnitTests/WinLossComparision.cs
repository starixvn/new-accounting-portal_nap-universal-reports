using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
{
    internal class WinLossComparision
    {
        internal static bool AreTwoSiteWinLossEqual(SiteWinLoss first, SiteWinLoss second)
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
            return first.Group == second.Group &&
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

        internal static bool AreTwoSiteWinLossListEqual(List<SiteWinLoss> first, List<SiteWinLoss> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            for (var i = 0; i < first.Count; i++)
            {
                if (!AreTwoSiteWinLossEqual(first[i], second[i]))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool AreTwoMainWinLossEqual(MainWinLoss first, MainWinLoss second)
        {
            return AreTwoWinLossListEqual(first.SportsbookDetail, second.SportsbookDetail)
                && AreTwoSiteWinLossEqual(first.GrandTotal, second.GrandTotal)
                && AreTwoSiteWinLossListEqual(first.Products, second.Products);
        }

        internal static bool AreTwoGroupSiteWinLossEqual(GroupOfSiteWinLoss first, GroupOfSiteWinLoss second)
        {
            return AreTwoSiteWinLossEqual(first.LiveGrandTotal, second.LiveGrandTotal)
                && AreTwoSiteWinLossEqual(first.NonLiveGrandTotal, second.NonLiveGrandTotal)
                && AreTwoSiteWinLossListEqual(first.Live, second.Live)
                && AreTwoSiteWinLossListEqual(first.NonLive, second.NonLive);
        }

        internal static bool AreTwoHybridGroupOfWinLossEqual(HybridGroupOfWinLoss first, HybridGroupOfWinLoss second)
        {
            return AreTwoWinLossEqual(first.GrandTotal, second.GrandTotal)
                && AreTwoGroupOfWinLossListEqual(first.WinLosses, second.WinLosses);
        }

        internal static bool AreTwoGroupOfWinLossListEqual(List<GroupOfWinLoss> first, List<GroupOfWinLoss> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            for (var i = 0; i < first.Count; i++)
            {
                if (!AreTwoGroupOfWinLossEqual(first[i], second[i]))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool AreTwoGroupOfWinLossEqual(GroupOfWinLoss first, GroupOfWinLoss second)
        {
            if (first.Name != second.Name || first.WinLosses.Count != second.WinLosses.Count)
            {
                return false;
            }

            for (var i = 0; i < first.WinLosses.Count; i++)
            {
                if (!AreTwoWinLossEqual(first.WinLosses[i], second.WinLosses[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
