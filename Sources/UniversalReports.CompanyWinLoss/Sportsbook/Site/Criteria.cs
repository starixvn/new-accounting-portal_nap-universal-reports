using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Sportsbook.Site
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public bool IsHedge { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Sportsbook-Site-{Source}";
        }
    }
}