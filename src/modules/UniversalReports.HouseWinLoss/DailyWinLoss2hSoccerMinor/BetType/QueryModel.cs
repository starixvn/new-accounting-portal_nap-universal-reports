using System;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int IsLive { get; set; } = 2;
    }
}