using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.SportsbookMatchDetail
{
    internal class WinLossComparision
    {
        internal static bool AreTwoWinLossEqual(WinLoss first, WinLoss second)
        {
            return first.MatchCode == second.MatchCode &&
                first.HomeName == second.HomeName &&
                first.AwayName == second.AwayName &&
                    first.MemberWinLoss == second.MemberWinLoss &&
                    first.SMAWinLoss == second.SMAWinLoss &&
                    first.Commission == second.Commission &&
                    first.RealIncome == second.RealIncome &&
                    first.RealTurnover == second.RealTurnover &&
                    first.Margin == second.Margin;
        }

        internal static bool AreTwoRawWinLossEqual(RawWinLoss first, RawWinLoss second)
        {
            return first.MatchCode == second.MatchCode &&
                first.HomeId == second.HomeId &&
                first.AwayId == second.AwayId &&
                    first.MemberWinLoss == second.MemberWinLoss &&
                    first.SMAWinLoss == second.SMAWinLoss &&
                    first.Commission == second.Commission &&
                    first.RealIncome == second.RealIncome &&
                    first.RealTurnover == second.RealTurnover;
        }

        internal static bool AreTwoWinLossListEqual(List<WinLoss> first, List<WinLoss> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            return !first.Where((t, i) => !AreTwoWinLossEqual(t, second[i])).Any();
        }
    }
}
