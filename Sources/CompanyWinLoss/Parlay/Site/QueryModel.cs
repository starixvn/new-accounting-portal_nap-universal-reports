using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Parlay.Site
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public int SportType { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }
    }
}