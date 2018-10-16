using System;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.OutrightMatchDetail
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int SportType { get; set; } = Constants.SportTypeSoccer;
    }
}