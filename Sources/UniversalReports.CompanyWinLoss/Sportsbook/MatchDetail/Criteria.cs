using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Sportsbook.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public bool IsHedge { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Sportsbook-MatchDetail-{Source}";
        }
    }
}