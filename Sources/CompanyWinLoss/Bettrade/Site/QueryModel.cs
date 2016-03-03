using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Bettrade.Site
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public string Site { get; set; }
    }
}