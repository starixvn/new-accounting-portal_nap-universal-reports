using System;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Soccer.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public bool IsMajor { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public bool IsNoDraw { get; set; } = false;

        public bool IsSabaSport { get; set; } = false;
    }
}