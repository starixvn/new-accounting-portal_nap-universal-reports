using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.SimpleGrid.SimpleCriteria
{
    public class UniversalSportTypeCriteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public override string GetSettingKey() => $"CN88WinLoss-Universal-SportType-{Source}";
    }
}