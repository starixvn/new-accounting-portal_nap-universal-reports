using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.MetricGaming.LiveNonLive
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-MetricGaming-LiveNonLive-{Source}";
        }
    }
}
