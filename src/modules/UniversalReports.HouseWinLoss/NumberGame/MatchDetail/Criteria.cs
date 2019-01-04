using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.NumberGame.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int LeagueId { get; set; }

        public int BetType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-NumberGame-MatchDetail-{Source}";
    }
}