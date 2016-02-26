using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail;

namespace UniversalReports.CompanyWinLoss.UnitTests.Cockfighting.MatchDetail
{
    internal class WinLossComparison
    {
        internal static bool CompareTwoMatchDetailIsEqual(WinLossModel first, WinLossModel second)
        {

            return CompareTwoListArenaIsEqual(first.Arenas, second.Arenas) &&
                CompareTwoWinLossIsEqual(first.Total, second.Total);
        }

        internal static bool CompareTwoListArenaIsEqual(List<ArenaWinLoss> first, List<ArenaWinLoss> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            return !first.Where((t, i) => !CompareTwoArenaIsEqual(t, second[i])).Any();
        }

        internal static bool CompareTwoArenaIsEqual(ArenaWinLoss first, ArenaWinLoss second)
        {
            return first.ArenaName == second.ArenaName &&
                CompareTwoListWinLossIsEqual(first.Matches, second.Matches) &&
                CompareTwoWinLossIsEqual(first.Total, second.Total);
        }

        internal static bool CompareTwoListWinLossIsEqual(List<WinLoss> first, List<WinLoss> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            return !first.Where((t, i) => !CompareTwoWinLossIsEqual(t, second[i])).Any();
        }

        internal static bool CompareTwoWinLossIsEqual(WinLoss first, WinLoss second)
        {
            return first.FightNo == second.FightNo &&
                first.ArenaId == second.ArenaId &&
                first.HomeName == second.HomeName &&
                first.AwayName == second.AwayName &&
                first.MemberWinLoss == second.MemberWinLoss &&
                first.SMAWinLoss == second.SMAWinLoss &&
                first.Commission == second.Commission &&
                first.RealIncome == second.RealIncome &&
                first.RealTurnover == second.RealTurnover &&
                first.Margin == second.Margin;
        }

        internal static bool CompareTwoRawWinLossIsEqual(RawWinLoss first, RawWinLoss second)
        {
            return first.FightNo == second.FightNo &&
                first.ArenaId == second.ArenaId &&
                first.HomeName == second.HomeName &&
                first.AwayName == second.AwayName &&
                first.MemberWinLoss == second.MemberWinLoss &&
                first.SMAWinLoss == second.SMAWinLoss &&
                first.Commission == second.Commission &&
                first.RealIncome == second.RealIncome &&
                first.RealTurnover == second.RealTurnover;
        }
    }
}
