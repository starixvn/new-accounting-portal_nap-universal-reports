using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Universal.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }
    }
}