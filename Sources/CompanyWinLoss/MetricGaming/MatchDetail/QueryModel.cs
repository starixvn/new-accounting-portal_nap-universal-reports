using System;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public int BetType { get; set; }
    }
}