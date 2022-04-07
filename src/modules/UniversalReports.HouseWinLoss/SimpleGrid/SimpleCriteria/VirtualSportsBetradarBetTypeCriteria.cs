using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class VirtualSportsBetradarBetTypeCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-VirtualSportsBetradar-BetType";
    }
}