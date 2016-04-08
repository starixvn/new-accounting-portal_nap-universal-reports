using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.OtherSports.SportType
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
            return $"CompanyWinLoss-OtherSports-SportType-{Source}";
        }
    }
}
