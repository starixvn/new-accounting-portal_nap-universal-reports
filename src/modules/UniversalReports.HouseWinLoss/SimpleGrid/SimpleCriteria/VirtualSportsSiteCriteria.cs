using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class VirtualSportsSiteCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-VirtualSports-Site";
    }
}