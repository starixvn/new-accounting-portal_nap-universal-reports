using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;

namespace UniversalReports.CompanyWinLoss.Soccer.MajorMinor
{
    using UniversalReports.CompanyWinLoss.Common.Criteria;

    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria
            {
                IsLive = IsLive
            };
            newCriteria.Update(source);

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Soccer-Major-Minor-{Source}";
        }
    }
}
