using System;
using UniversalReports.CN88WinLoss.Configuration;

namespace UniversalReports.CN88WinLoss.OtherSports.SportType
{
    public class QueryModel
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;
    }
}