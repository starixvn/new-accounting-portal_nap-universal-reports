using System;

namespace UniversalReports.HouseWinLoss.Casino.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int CasinoProductId { get; set; }
    }
}