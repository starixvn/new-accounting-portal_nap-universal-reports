using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Soccer.MajorOrMinorBetTypes
{
    public class SoccerBetTypeGroupConstants
    {
        public static readonly List<int> BetTypeGroup1 = new List<int>
        {
            1, // Handicap
            5, // _1x2BetType
            24, // DoubleChanceBetType
            25, // DrawNoBetBetType
            28, // _3wayHandicap
            121, // HomeNoBetBetType
            122, // AwayNoBetBetType
            123, // DrawNoDrawBetType
            301 // MyanmarHandicap
        };

        public static readonly List<int> BetTypeGroup2 = new List<int>
        {
            3, // OverUnder2
            6, // TotalGoal
            2, // OddEvenBetType
            302 // MyanmarOverUnder
        };

        public static readonly List<int> BetTypeGroup3 = new List<int>
        {
            7, // _1stHandicap
            15, // _1st1x2BetType
            151, // _1stDoubleChange
            303 // _1stMyanmarHandicap
        };

        public static List<int> BetTypeGroup123()
        {
            List<int> betTypeGroup123 = new List<int>();
            betTypeGroup123.AddRange(BetTypeGroup1);
            betTypeGroup123.AddRange(BetTypeGroup2);
            betTypeGroup123.AddRange(BetTypeGroup3);

            return betTypeGroup123;
        }

        public static readonly List<int> MainBetTypes = new List<int>
        {
            1, // Handicap
            7, // _1stHandicap
            3, // OverUnder2
            8 // _1stOverUnder
        };
    }
}
