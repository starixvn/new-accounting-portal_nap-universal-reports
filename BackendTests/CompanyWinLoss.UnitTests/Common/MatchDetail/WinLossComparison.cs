using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.MatchDetail;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetail
{
    internal class WinLossComparison
    {
        internal static bool AreEqual(List<LeagueWinLoss> expected, List<LeagueWinLoss> model)
        {
            if (expected.Count != model.Count)
            {
                return false;
            }

            return !expected.Where((t, i) => !AreEqual(t, model[i])).Any();
        }

        internal static bool AreEqual(LeagueWinLoss expected, LeagueWinLoss model)
        {
            return expected.LeagueName == model.LeagueName &&
                AreEqual(expected.Matches, model.Matches) &&
                AreEqual(expected.Total, model.Total);
        }

        internal static bool AreEqual(List<WinLoss> expected, List<WinLoss> model)
        {
            if (expected.Count != model.Count)
            {
                return false;
            }

            return !expected.Where((t, i) => !AreEqual(t, model[i])).Any();
        }

        internal static bool AreEqual(WinLoss expected, WinLoss model)
        {
            return expected.MatchId == model.MatchId &&
                expected.MatchCode == model.MatchCode &&
                expected.IsNeutral == model.IsNeutral &&
                expected.HomeId == model.HomeId &&
                expected.AwayId == model.AwayId &&
                expected.HomeName == model.HomeName &&
                expected.AwayName == model.AwayName &&
                expected.LeagueId == model.LeagueId &&
                expected.LeagueName == model.LeagueName &&
                expected.MemberWinLoss == model.MemberWinLoss &&
                expected.SMAWinLoss == model.SMAWinLoss &&
                expected.Commission == model.Commission &&
                expected.RealIncome == model.RealIncome &&
                expected.VirtualIncome == model.VirtualIncome &&
                expected.VarianceIncome == model.VarianceIncome &&
                expected.RealTurnover == model.RealTurnover &&
                expected.VirtualTurnover == model.VirtualTurnover &&
                expected.RealMargin == model.RealMargin;
        }

        internal static bool AreEqual(RawWinLoss expected, RawWinLoss model)
        {
            return expected.MatchId == model.MatchId &&
               expected.MatchCode == model.MatchCode &&
               expected.IsNeutral == model.IsNeutral &&
               expected.HomeId == model.HomeId &&
               expected.AwayId == model.AwayId &&
               expected.HomeName == model.HomeName &&
               expected.AwayName == model.AwayName &&
               expected.LeagueId == model.LeagueId &&
               expected.MemberWinLoss == model.MemberWinLoss &&
               expected.SMAWinLoss == model.SMAWinLoss &&
               expected.Commission == model.Commission &&
               expected.RealIncome == model.RealIncome &&
               expected.VirtualIncome == model.VirtualIncome &&
               expected.VarianceIncome == model.VarianceIncome &&
               expected.RealTurnover == model.RealTurnover &&
               expected.VirtualTurnover == model.VirtualTurnover;
        }
    }
}
