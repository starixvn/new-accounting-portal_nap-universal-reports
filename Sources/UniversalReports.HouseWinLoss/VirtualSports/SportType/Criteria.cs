using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.VirtualSports.SportType
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"HouseWinLoss-VirtualSports-SportType-{Source}";
        }
    }
}