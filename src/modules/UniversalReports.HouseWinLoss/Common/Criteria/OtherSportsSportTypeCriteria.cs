using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class OtherSportsSportTypeCriteria : WinLossCriteria
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"HouseWinLoss-OtherSports-SportType-LiveStatus-{Source}";
    }
}