using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Sportsbook.MatchDetail
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public int SportType { get; set; }

        public int BetType { get; set; }

        private bool IsLive { get; set; }

        private bool IsHedge { get; set; }
    }
}