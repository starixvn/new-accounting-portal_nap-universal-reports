using System;
using System.ComponentModel.DataAnnotations;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Sportsbook.MatchDetail
{
    public class QueryModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        [Required]
        public int SportType { get; set; }

        [Required]
        public int BetType { get; set; }

        private int IsLive { get; set; } = Constants.LiveDefault;

        private bool IsHedge { get; set; }
    }
}