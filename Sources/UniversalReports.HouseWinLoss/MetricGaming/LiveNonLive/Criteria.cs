using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.MetricGaming.LiveNonLive
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"HouseWinLoss-MetricGaming-LiveNonLive-{Source}";
        }
    }
}
