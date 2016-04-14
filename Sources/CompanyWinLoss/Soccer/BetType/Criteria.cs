using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Soccer.BetType
{
    public class Criteria : WinLossCriteria
    {
        public bool IsMajor { get; set; }

        public int IsLive { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria
            {
                IsMajor = IsMajor,
                IsLive = IsLive
            };
            newCriteria.Update(source);
            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Soccer-BetType-{Source}";
        }
    }
}
