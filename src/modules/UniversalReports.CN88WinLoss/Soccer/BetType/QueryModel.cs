using System;
using UniversalReports.CN88WinLoss.Configuration;

namespace UniversalReports.CN88WinLoss.Soccer.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public bool IsMajor { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public bool IsBetBuilder { get; set; }
    }
}