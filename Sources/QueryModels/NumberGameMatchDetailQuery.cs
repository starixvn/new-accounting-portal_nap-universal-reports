using NAP.Reports.MVC.Validation;
using System;

namespace NAP.Reports.CompanyWinLoss.QueryModels
{
    public class NumberGameMatchDetailQuery
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public int SportType { get; set; }

        public int BetType { get; set; }

        public bool IsLive { get; set; }
    }
}
