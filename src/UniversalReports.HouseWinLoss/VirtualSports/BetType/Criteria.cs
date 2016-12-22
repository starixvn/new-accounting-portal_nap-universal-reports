using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.VirtualSports.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-VirtualSports-BetType-{Source}";
        }
    }
}