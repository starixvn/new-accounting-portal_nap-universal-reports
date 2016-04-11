using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetailServices
{
    internal class WinLossComparison
    {
        internal static bool AreEqual(List<LeagueWinLoss> first, List<LeagueWinLoss> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            return !first.Where((t, i) => !AreEqual(t, second[i])).Any();
        }

        internal static bool AreEqual(LeagueWinLoss first, LeagueWinLoss second)
        {
            return first.LeagueName == second.LeagueName &&
                AreEqual(first.Matches, second.Matches) &&
                AreEqual(first.Total, second.Total);
        }

        internal static bool AreEqual(List<MatchDetailWinLoss> first, List<MatchDetailWinLoss> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            return !first.Where((t, i) => !AreEqual(t, second[i])).Any();
        }

        internal static bool AreEqual(MatchDetailWinLoss first, MatchDetailWinLoss second)
        {
            return first.MatchId == second.MatchId &&
                first.MatchCode == second.MatchCode &&
                first.IsNeutral == second.IsNeutral &&
                first.HomeId == second.HomeId &&
                first.AwayId == second.AwayId &&
                first.HomeName == second.HomeName &&
                first.AwayName == second.AwayName &&
                first.LeagueId == second.LeagueId &&
                first.LeagueName == second.LeagueName &&
                first.MemberWinLoss == second.MemberWinLoss &&
                first.SMAWinLoss == second.SMAWinLoss &&
                first.Commission == second.Commission &&
                first.RealIncome == second.RealIncome &&
                first.VirtualIncome == second.VirtualIncome &&
                first.VarianceIncome == second.VarianceIncome &&
                first.RealTurnover == second.RealTurnover &&
                first.VirtualTurnover == second.VirtualTurnover &&
                first.Margin == second.Margin;
        }

        internal static bool AreEqual(MatchDetailRawWinLoss first, MatchDetailRawWinLoss second)
        {
            return first.MatchId == second.MatchId &&
               first.MatchCode == second.MatchCode &&
               first.IsNeutral == second.IsNeutral &&
               first.HomeId == second.HomeId &&
               first.AwayId == second.AwayId &&
               first.HomeName == second.HomeName &&
               first.AwayName == second.AwayName &&
               first.LeagueId == second.LeagueId &&
               first.MemberWinLoss == second.MemberWinLoss &&
               first.SMAWinLoss == second.SMAWinLoss &&
               first.Commission == second.Commission &&
               first.RealIncome == second.RealIncome &&
               first.VirtualIncome == second.VirtualIncome &&
               first.VarianceIncome == second.VarianceIncome &&
               first.RealTurnover == second.RealTurnover &&
               first.VirtualTurnover == second.VirtualTurnover;
        }
    }
}
