using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class OtherSportsBetTypeCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"HouseWinLoss-OtherSports-BetType-{Source}";
    }
}