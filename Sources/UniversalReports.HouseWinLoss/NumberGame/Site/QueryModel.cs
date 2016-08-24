using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.HouseWinLoss.NumberGame.Site
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int SportType { get; set; }

        public int BetType { get; set; }

        public bool IsLive { get; set; }

        public string Site { get; set; }
    }
}