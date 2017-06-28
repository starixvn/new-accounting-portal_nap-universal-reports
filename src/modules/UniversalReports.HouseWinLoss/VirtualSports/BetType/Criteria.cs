using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.VirtualSports.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-VirtualSports-BetType-{Source}";
    }
}