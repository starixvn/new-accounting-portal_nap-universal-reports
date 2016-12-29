using System;

namespace UniversalReports.HouseWinLoss.FishingWorld.BetType
{
    public class QueryModel
    {
        public int ProductId { get; set; }

        public int SportType { get; set; } = 0;

        public int IsLive { get; set; } = 2;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;
    }
}