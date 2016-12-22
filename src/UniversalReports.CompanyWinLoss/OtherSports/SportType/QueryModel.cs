using System;
using UniversalReports.CompanyWinLoss.Configuration;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.OtherSports.SportType
{
    public class QueryModel
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;
    }
}