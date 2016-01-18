using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
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
            return first.GroupName == second.GroupName &&
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
            return first.GroupName == second.GroupName &&
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

            for (var i = 0; i < first.Count; i++)
            {
                if (!AreTwoWinLossEqual(first[i], second[i]))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool AreTwoSiteWinLossSummaryListEqual(List<SiteWinLossSummary> first, List<SiteWinLossSummary> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            for (var i = 0; i < first.Count; i++)
            {
                if (!AreTwoSiteWinLossSummaryEqual(first[i], second[i]))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool AreTwoProductWinLossEqual(ProductWinLoss first, ProductWinLoss second)
        {
            return AreTwoWinLossListEqual(first.SportsbookDetail, second.SportsbookDetail)
                && AreTwoSiteWinLossSummaryEqual(first.GrandTotal, second.GrandTotal)
                && AreTwoSiteWinLossSummaryListEqual(first.Products, second.Products);
        }

        internal static bool AreTwoGroupSiteWinLossEqual(NumberGameBetTypeWinLossSummary first, NumberGameBetTypeWinLossSummary second)
        {
            return AreTwoSiteWinLossSummaryEqual(first.LiveGrandTotal, second.LiveGrandTotal)
                && AreTwoSiteWinLossSummaryEqual(first.NonLiveGrandTotal, second.NonLiveGrandTotal)
                && AreTwoSiteWinLossSummaryListEqual(first.Live, second.Live)
                && AreTwoSiteWinLossSummaryListEqual(first.NonLive, second.NonLive);
        }

        internal static bool AreTwoNumberGameMatchDetailWinLossEqual(NumberGameMatchDetailWinLoss first, NumberGameMatchDetailWinLoss second)
        {
            if (first.Leagues.Count != second.Leagues.Count)
            {
                return false;
            }

            if (!AreTwoWinLossEqual(first.Total, second.Total))
            {
                return false;
            }

            for (var i = 0; i < first.Leagues.Count; i++)
            {
                if (!AreTwoNumberGameLeagueWinLossEqual(first.Leagues[i], second.Leagues[i]))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool AreTwoNumberGameLeagueWinLossEqual(NumberGameLeagueWinLoss first, NumberGameLeagueWinLoss second)
        {
            return first.LeagueName == second.LeagueName
                && AreTwoWinLossListEqual(first.Matches, second.Matches);
        }

        internal static bool AreTwoSiteWinLossEqual(SiteWinLoss first, SiteWinLoss second)
        {
            return AreTwoWinLossListEqual(first.Sites, second.Sites)
                && AreTwoWinLossEqual(first.Total, second.Total);
        }
    }
}
