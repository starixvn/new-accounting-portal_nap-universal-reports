using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.SimpleGrid.SimpleCriteria
{
    public class NumberGameSiteCriteria : WinLossCriteria
    {
        public int LeagueId { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey() => $"CN88WinLoss-NumberGame-Site-{Source}";
    }
}