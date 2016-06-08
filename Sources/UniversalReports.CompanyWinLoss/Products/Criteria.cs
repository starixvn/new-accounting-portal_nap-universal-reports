using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Products-{Source}";
        }
    }
}