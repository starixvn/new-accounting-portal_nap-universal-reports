using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Configuration;

namespace UniversalReports.CompanyWinLoss.MetricGaming.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-MetricGaming-BetType-{Source}";
        }
    }
}
