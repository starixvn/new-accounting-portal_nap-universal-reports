using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;

namespace UniversalReports.CompanyWinLoss.Soccer.BetType
{
    using UniversalReports.CompanyWinLoss.Common.Criteria;

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
