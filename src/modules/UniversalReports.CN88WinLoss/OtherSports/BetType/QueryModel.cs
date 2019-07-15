using System;
using UniversalReports.CN88WinLoss.Configuration;

namespace UniversalReports.CN88WinLoss.OtherSports.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int SportType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;
    }
}