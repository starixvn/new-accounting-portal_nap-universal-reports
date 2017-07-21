using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.VirtualSportsBetradar.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-VirtualSportsBetradar-BetType-{Source}";
    }
}