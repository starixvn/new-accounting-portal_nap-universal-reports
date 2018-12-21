using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class VirtualSportsBetradarSportTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-VirtualSportsBetradar-SportType-{Source}";
    }
}