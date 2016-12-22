using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Configuration;

namespace UniversalReports.CompanyWinLoss.MetricGaming.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-MetricGaming-Site-{Source}";
        }
    }
}