using System;

namespace UniversalReports.HouseWinLoss.Universal.Site
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public string Site { get; set; }

        public int BetType { get; set; }

        public int IsLive { get; set; }
    }
}