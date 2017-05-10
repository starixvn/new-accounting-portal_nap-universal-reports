using System;

namespace UniversalReports.HouseWinLoss.CashOut.Site
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public string Site { get; set; }
    }
}