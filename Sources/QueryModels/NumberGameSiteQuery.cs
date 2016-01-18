using NAP.Reports.MVC.Validation;
using System;

namespace NAP.Reports.CompanyWinLoss.QueryModels
{
    public class NumberGameSiteQuery
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public int SportType { get; set; }

        public int BetType { get; set; }

        public bool IsLive { get; set; }

        public int Site { get; set; }
    }
}
