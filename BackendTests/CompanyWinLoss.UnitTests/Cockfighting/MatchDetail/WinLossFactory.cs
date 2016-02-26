using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail;

namespace UniversalReports.CompanyWinLoss.UnitTests.Cockfighting.MatchDetail
{
    internal static class WinLossFactory
    {
        internal static RawWinLoss CreateRawWinLoss(
           string fightNo,
           int arenaId,
           string homeName,
           string awayName,
           decimal memberWinLoss,
           decimal smaWinLoss,
           decimal commission,
           decimal realIncome,
           decimal realTurnover)
        {
            return new RawWinLoss
            {
                FightNo = fightNo,
                ArenaId = arenaId,
                HomeName = homeName,
                AwayName = awayName,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                RealTurnover = realTurnover
            };
        }

        internal static WinLoss CreateWinLoss(
           string fightNo,
           int arenaId,
           string homeName,
           string awayName,
           decimal memberWinLoss,
           decimal smaWinLoss,
           decimal commission,
           decimal realIncome,
           decimal realTurnover,
           decimal margin)
        {
            return new WinLoss
            {
                FightNo = fightNo,
                ArenaId = arenaId,
                HomeName = homeName,
                AwayName = awayName,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                RealTurnover = realTurnover,
                Margin = margin
            };
        }

        internal static List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var match1 = CreateRawWinLoss("match1", 1, "home1", "away1", 100, 120, 10, 200, 400);
            var match2 = CreateRawWinLoss("match2", 1, "home2", "away2", 120, 150, 20, 100, 200);
            var match3 = CreateRawWinLoss("match3", 2, "home3", "away3", 150, 200, 30, 150, 300);
            var match4 = CreateRawWinLoss("match4", 2, "home4", "away4", 200, 250, 40, 150, 300);

            return new List<RawWinLoss> { match1, match2, match3, match4 };
        }

        internal static WinLossModel CreateExpectMatchDetail()
        {
            var arenas = CreateExpectedArenaWinLoss();
            var total = CreateExpectTotal();
            return new WinLossModel
            {
                Arenas = arenas,
                Total = total
            };
        }

        internal static List<ArenaWinLoss> CreateExpectedArenaWinLoss()
        {
            var firstArenaMatches = CreateExpectedFirstArenaMatches();
            var firstArenaTotal = CreateExpectedFirstArenaTotal();
            var firstArena = CreateExpectedArenaWinLoss(firstArenaMatches, firstArenaTotal);

            var secondArenaMatches = CreateExpectedSecondArenaMatches();
            var secondArenaTotal = CreateExpectedSecondArenaTotal();
            var secondArena = CreateExpectedArenaWinLoss(secondArenaMatches, secondArenaTotal);

            return new List<ArenaWinLoss> { firstArena, secondArena };
        }

        internal static ArenaWinLoss CreateExpectedArenaWinLoss(List<WinLoss> winLoss, WinLoss total)
        {
            return new ArenaWinLoss
            {
                ArenaName = "Any Arena",
                Matches = winLoss,
                Total = total
            };
        }

        internal static List<WinLoss> CreateExpectedFirstArenaMatches()
        {
            var match1 = CreateWinLoss("match1", 1, "home1", "away1", 100, 120, 10, 200, 400, 2 / 4m);
            var match2 = CreateWinLoss("match2", 1, "home2", "away2", 120, 150, 20, 100, 200, 1 / 2m);
            return new List<WinLoss> { match1, match2 };
        }

        internal static List<WinLoss> CreateExpectedSecondArenaMatches()
        {
            var match3 = CreateWinLoss("match3", 2, "home3", "away3", 150, 200, 30, 150, 300, 15 / 30m);
            var match4 = CreateWinLoss("match4", 2, "home4", "away4", 200, 250, 40, 150, 300, 15 / 30m);
            return new List<WinLoss> { match3, match4 };
        }

        internal static WinLoss CreateExpectTotal()
        {
            return CreateWinLoss(string.Empty, 0, string.Empty, string.Empty, 570, 720, 100, 600, 1200, 6 / 12m);
        }

        internal static WinLoss CreateExpectedFirstArenaTotal()
        {
            return CreateWinLoss(string.Empty, 0, string.Empty, string.Empty, 220, 270, 30, 300, 600, 3 / 6m);
        }

        internal static WinLoss CreateExpectedSecondArenaTotal()
        {
            return CreateWinLoss(string.Empty, 0, string.Empty, string.Empty, 350, 450, 70, 300, 600, 3 / 6m);
        }
    }
}
