using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Soccer.MajorMinor
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public int IsLive { get; set; }
    }
}
