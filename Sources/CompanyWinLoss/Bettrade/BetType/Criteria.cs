using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Bettrade.BetType
{
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
            return $"CompanyWinLoss-Bettrade-BetType-{Source}";
        }
    }
}
