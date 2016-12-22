using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Products
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"HouseWinLoss-Products-{Source}";
        }
    }
}