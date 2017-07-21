using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.VirtualSportsBetradar.SportType
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-VirtualSportsBetradar-SportType-{Source}";
    }
}