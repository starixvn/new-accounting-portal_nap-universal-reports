using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.MetricGaming.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-MetricGaming-Site-{Source}";
        }
    }
}