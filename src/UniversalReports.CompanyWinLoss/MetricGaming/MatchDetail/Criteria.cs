using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Configuration;

namespace UniversalReports.CompanyWinLoss.MetricGaming.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-MetricGaming-MatchDetail-{Source}";
        }
    }
}