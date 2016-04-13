using System;
using System.ComponentModel.DataAnnotations;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Sportsbook.Site
{
    public class QueryModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public int SportType { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        private int IsLive { get; set; } = Constants.LiveDefault;

        private bool IsHedge { get; set; }
    }
}