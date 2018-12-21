using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class VirtualSportsSportTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-VirtualSports-SportType-{Source}";
    }
}