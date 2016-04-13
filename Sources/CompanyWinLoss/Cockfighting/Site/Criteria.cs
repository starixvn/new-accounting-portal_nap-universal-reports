using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Cockfighting.Site
{
    public class Criteria : WinLossCriteria
    {
        public string Site { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria();
            newCriteria.Update(source);
            newCriteria.Site = Site;

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Cockfighting-Site-{Source}";
        }
    }
}