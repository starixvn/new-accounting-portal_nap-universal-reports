using System;
using System.ComponentModel.DataAnnotations;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.MetricGaming.MatchDetail
{
    public class QueryModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        [Required]
        public int BetType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;
    }
}