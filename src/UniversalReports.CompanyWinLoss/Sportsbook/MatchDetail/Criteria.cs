using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Configuration;

namespace UniversalReports.CompanyWinLoss.Sportsbook.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public int IsHedge { get; set; } = Constants.HedgeDefault;

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Sportsbook-MatchDetail-{Source}";
        }
    }
}