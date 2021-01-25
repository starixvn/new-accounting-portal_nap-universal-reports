using System;

namespace UniversalReports.HouseWinLoss.OtherSports.LiveNonLive
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public bool IsNoDraw { get; set; } = false;
    }
}