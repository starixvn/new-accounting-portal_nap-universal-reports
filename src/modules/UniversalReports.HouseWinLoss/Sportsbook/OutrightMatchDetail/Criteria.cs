using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Sportsbook.OutrightMatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public bool IsNoDraw { get; set; } = false;

        public bool IsSabaSport { get; set; } = false;

        public override string GetSettingKey() => $"HouseWinLoss-Sportsbook-Outright-MatchDetail-{Source}";
    }
}