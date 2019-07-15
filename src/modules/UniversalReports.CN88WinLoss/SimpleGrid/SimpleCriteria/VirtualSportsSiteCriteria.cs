using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.SimpleGrid.SimpleCriteria
{
    public class VirtualSportsSiteCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey() => $"CN88WinLoss-VirtualSports-Site-{Source}";
    }
}