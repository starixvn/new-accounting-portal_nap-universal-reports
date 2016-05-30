using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Racing.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public int SportType { get; set; }
    }
}