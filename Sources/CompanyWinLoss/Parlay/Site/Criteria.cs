using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Parlay.Site
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
            return $"CompanyWinLoss-SystemParlay-{Source}";
        }
    }
}