using System;
using System.ComponentModel.DataAnnotations;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.OtherSports.BetType
{
    public class QueryModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        [Required]
        public string SportType { get; set; }

        public int IsLive { get; set; } = Common.Constants.LiveDefault;
    }
}