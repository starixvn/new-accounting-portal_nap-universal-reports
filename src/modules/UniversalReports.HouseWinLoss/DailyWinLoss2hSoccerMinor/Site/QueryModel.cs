using System;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.Site
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int SportType { get; set; } = Constants.SportTypeSoccer;

        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public int IsHedge { get; set; } = Constants.HedgeDefault;

        public int IsCorners { get; set; } = Constants.CornersDefault;

        public int IsSabaSport { get; set; } = Constants.IsAllSportDefault;
    }
}