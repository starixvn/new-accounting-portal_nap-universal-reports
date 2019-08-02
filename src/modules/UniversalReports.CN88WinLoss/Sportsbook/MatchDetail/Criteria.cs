using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Configuration;

namespace UniversalReports.CN88WinLoss.Sportsbook.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public int IsHedge { get; set; } = Constants.HedgeDefault;

        public override string GetSettingKey()
        {
            const int betBuilderBetType = 38;
            return BetType == betBuilderBetType ? $"CN88WinLoss-BetBuilder-MatchDetail-{Source}" : $"CN88WinLoss-Sportsbook-MatchDetail-{Source}";
        }
    }
}