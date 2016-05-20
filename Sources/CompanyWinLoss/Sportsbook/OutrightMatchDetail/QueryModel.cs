using System;
using System.ComponentModel.DataAnnotations;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Sportsbook.OutrightMatchDetail
{
    public class QueryModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        [Required]
        public int SportType { get; set; }
    }
}