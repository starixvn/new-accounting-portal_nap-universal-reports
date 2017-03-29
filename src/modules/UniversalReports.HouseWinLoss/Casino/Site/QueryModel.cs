using System;

namespace UniversalReports.HouseWinLoss.Casino.Site
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int BetType { get; set; }

        public string Site { get; set; }
    }
}