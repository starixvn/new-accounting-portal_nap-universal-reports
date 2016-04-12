namespace UniversalReports.CompanyWinLoss.Products
{
    using UniversalReports.CompanyWinLoss.Common.Criteria;
    using UniversalReports.CompanyWinLoss.Common.Models;

    public class Criteria : WinLossCriteria
    {
        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria();
            newCriteria.Update(source);

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Products-{Source}";
        }
    }
}