using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class SoccerMinor2hSiteCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public int IsHedge { get; set; } = Constants.HedgeDefault;

        public override string GetSettingKey() => $"HouseWinLoss-Sportsbook-Site-{Source}";
    }
}