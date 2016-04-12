namespace UniversalReports.CompanyWinLoss.Soccer.LiveNonLiveSportTypes
{
    using System;
    using UniversalReports.MVC.Validation;

    class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }
    }
}
