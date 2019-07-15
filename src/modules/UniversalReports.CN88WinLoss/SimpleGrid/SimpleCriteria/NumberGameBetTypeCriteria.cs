using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.SimpleGrid.SimpleCriteria
{
    public class NumberGameBetTypeCriteria : WinLossCriteria
    {
        public int LeagueId { get; set; }

        public int SportType { get; set; }

        public override string GetSettingKey() => $"CN88WinLoss-NumberGame-BetType-{Source}";
    }
}