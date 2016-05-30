using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Racing.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria();
            newCriteria.Update(source);
            newCriteria.SportType = SportType;

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Racing-BetType-{Source}";
        }
    }
}