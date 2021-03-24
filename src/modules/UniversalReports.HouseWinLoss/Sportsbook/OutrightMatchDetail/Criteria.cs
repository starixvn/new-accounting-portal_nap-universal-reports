using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Sportsbook.OutrightMatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public bool IsNoDraw { get; set; } = false;

        public int IsSabaSport { get; set; } = Constants.IsSabaSportDefault;

        public override string GetSettingKey() => $"HouseWinLoss-Sportsbook-Outright-MatchDetail-{Source}";
    }
}