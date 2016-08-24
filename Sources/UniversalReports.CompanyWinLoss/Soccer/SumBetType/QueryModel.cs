using System;
using UniversalReports.CompanyWinLoss.Configuration;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public bool IsMajor { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;
    }
}
