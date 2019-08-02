using System;

namespace UniversalReports.CN88WinLoss.NumberGame.MatchDetail
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int LeagueId { get; set; }

        public int BetType { get; set; }

        public bool IsLive { get; set; }
    }
}