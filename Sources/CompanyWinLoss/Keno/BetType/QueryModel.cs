using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Keno.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public string BreadCrumb { get; set; }
    }
}
