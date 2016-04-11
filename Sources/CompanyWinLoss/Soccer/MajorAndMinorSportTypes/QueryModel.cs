namespace UniversalReports.CompanyWinLoss.Soccer.MajorAndMinorSportTypes
{
    using System;
    using UniversalReports.MVC.Validation;

    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public int IsLive { get; set; }
    }
}
