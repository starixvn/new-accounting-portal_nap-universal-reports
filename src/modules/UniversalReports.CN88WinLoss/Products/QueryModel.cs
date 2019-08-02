using System;

namespace UniversalReports.CN88WinLoss.Products
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public string[] Permissions { get; set; }
    }
}