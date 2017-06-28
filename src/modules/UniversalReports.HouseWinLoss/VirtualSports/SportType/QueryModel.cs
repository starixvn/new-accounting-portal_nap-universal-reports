using System;

namespace UniversalReports.HouseWinLoss.VirtualSports.SportType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int ProductId { get; set; }
    }
}