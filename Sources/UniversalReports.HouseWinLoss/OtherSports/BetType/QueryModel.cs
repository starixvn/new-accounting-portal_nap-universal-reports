using System;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Validation;

namespace UniversalReports.HouseWinLoss.OtherSports.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int SportType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;
    }
}