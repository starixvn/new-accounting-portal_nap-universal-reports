using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.MetricGaming.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-MetricGaming-Site-{Source}";
        }
    }
}