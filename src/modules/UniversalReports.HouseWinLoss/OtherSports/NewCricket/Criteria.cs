using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.OtherSports.NewCricket
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public bool IsNoDraw { get; set; } = false;

        public bool IsSabaSport { get; set; } = false;

        public override string GetSettingKey() => $"HouseWinLoss-OtherSports-BetType-{Source}";
    }
}