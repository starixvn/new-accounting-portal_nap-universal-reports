using System;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Soccer.MajorMinor
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int IsLive { get; set; } = Constants.LiveDefault;

        public bool IsNoDraw { get; set; } = false;

        public int IsSabaSport { get; set; } = Constants.IsSabaSportDefault;
    }
}