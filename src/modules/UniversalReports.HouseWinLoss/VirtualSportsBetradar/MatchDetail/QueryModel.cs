using System;

namespace UniversalReports.HouseWinLoss.VirtualSportsBetradar.MatchDetail
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int SportType { get; set; }

        public int BetType { get; set; }
    }
}