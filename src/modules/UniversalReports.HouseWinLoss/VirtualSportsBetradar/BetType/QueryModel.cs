using System;

namespace UniversalReports.HouseWinLoss.VirtualSportsBetradar.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int SportType { get; set; }
    }
}