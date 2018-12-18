using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class MetricGamingBetTypeCriteria : WinLossCriteria
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"HouseWinLoss-MetricGaming-BetType-LiveStatus-{Source}";
    }
}