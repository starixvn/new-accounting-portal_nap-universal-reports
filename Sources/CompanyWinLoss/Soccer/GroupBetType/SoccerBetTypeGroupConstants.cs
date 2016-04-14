using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    public class SoccerBetTypeGroupConstants
    {
        public enum BetTypeGroup1
        {
            Handicap = 1,
            _1x2BetType = 5,
            DoubleChanceBetType = 24,
            DrawNoBetBetType = 25,
            _3wayHandicap = 28,
            HomeNoBetBetType = 121,
            AwayNoBetBetType = 122,
            DrawNoDrawBetType = 123,
            MyanmarHandicap = 301
        }

        public enum BetTypeGroup2
        {
            OverUnder2 = 3,
            TotalGoal = 6,
            OddEvenBetType = 2,
            MyanmarOverUnder = 302
        }

        public enum BetTypeGroup3
        {
            _1stHandicap = 7,
            _1st1x2BetType = 15,
            _1stDoubleChange = 151,
            _1stMyanmarHandicap = 303
        }
      
        public enum MainBetTypes
        {
            Handicap = 1,
            _1stHandicap = 7,
            OverUnder2 = 3,
            _1stOverUnder = 8
        }

        public static List<int> BetTypeGroup123()
        {
            var group1Arr = (int[])Enum.GetValues(typeof(BetTypeGroup1));
            var group2Arr = (int[])Enum.GetValues(typeof(BetTypeGroup2));
            var group3Arr = (int[])Enum.GetValues(typeof(BetTypeGroup3));
            var betTypeGroup123 = group1Arr.Concat(group2Arr).Concat(group3Arr);

            return betTypeGroup123.ToList();
        }
    }
}
