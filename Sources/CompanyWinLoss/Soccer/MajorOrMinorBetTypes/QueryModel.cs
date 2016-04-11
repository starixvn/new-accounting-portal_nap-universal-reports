namespace UniversalReports.CompanyWinLoss.Soccer.MajorOrMinorBetTypes
{
    using System;
    using UniversalReports.MVC.Validation;

    class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }
        public bool IsMajor { get; set; }

        public int IsLive { get; set; }
    }
}
