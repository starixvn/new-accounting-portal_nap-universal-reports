using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.NumberGame.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int LeagueId { get; set; }

        public int BetType { get; set; }

        public override string GetSettingKey() => $"CN88WinLoss-NumberGame-MatchDetail-{Source}";
    }
}