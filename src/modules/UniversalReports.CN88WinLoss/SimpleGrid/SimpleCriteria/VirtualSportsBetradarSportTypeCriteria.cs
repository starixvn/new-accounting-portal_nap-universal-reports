using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.SimpleGrid.SimpleCriteria
{
    public class VirtualSportsBetradarSportTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"CN88WinLoss-VirtualSportsBetradar-SportType-{Source}";
    }
}