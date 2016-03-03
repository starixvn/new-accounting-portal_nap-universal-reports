using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }
    }
}