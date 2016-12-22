using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Racing.SportType
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"HouseWinLoss-Racing-SportType-{Source}";
        }
    }
}