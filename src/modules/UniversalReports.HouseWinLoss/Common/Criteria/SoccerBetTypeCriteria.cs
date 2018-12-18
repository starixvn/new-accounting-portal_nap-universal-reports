using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class SoccerBetTypeCriteria : WinLossCriteria
    {
        public bool IsMajor { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"HouseWinLoss-Soccer-BetType-{Source}";
    }
}