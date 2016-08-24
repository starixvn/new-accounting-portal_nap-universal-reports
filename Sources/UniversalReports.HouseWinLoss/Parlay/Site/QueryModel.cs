using System;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Validation;

namespace UniversalReports.HouseWinLoss.Parlay.Site
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public string Site { get; set; } = Constants.SiteDefault;
    }
}