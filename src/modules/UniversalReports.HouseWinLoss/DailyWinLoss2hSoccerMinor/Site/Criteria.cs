using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.Site
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public int IsHedge { get; set; } = Constants.HedgeDefault;

        public int IsCorners { get; set; } = Constants.CornersDefault;

        public int IsSabaSport { get; set; } = Constants.IsAllSportDefault;

        public override string GetSettingKey() => $"HouseWinLoss-Sportsbook-Site-{Source}";
    }
}