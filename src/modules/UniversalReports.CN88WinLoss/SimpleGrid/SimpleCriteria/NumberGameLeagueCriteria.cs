using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.SimpleGrid.SimpleCriteria
{
    public class NumberGameLeagueCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey() => $"CN88WinLoss-NumberGame-League-{Source}";
    }
}