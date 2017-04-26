using System;

namespace UniversalReports.HouseWinLoss.Universal.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int ProductId { get; set; }

        public int SportType { get; set; }

        public int IsLive { get; set; }
    }
}