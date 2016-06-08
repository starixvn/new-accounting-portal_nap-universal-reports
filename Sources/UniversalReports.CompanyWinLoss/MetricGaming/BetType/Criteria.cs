using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Criteria;

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
