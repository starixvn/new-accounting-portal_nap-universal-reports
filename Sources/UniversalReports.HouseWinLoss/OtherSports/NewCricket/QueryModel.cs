using System;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.OtherSports.NewCricket
{
    public class QueryModel
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int SportType { get; set; }

        public bool NormalMode { get; set; } = true;
    }
}
