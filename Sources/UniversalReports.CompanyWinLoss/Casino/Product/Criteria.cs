using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Casino.Product
{
    public class Criteria : WinLossCriteria
    {
        public int CasinoType { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria { CasinoType = CasinoType };
            newCriteria.Update(source);

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Casino-Product-{Source}";
        }
    }
}