using System;

namespace UniversalReports.HouseWinLoss.ColossusBet.Site
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public string Site { get; set; }

        public int BetType { get; set; }

        public bool IsFreePlay { get; set; }
    }
}