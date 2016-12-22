using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Soccer.LiveNonLive
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;
    }
}
