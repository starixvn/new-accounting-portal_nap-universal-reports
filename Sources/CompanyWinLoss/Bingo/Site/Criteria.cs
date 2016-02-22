using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Bingo.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria();
            newCriteria.Update(source);
            newCriteria.BetType = BetType;
            newCriteria.Site = Site;

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Bingo-Site-{Source}";
        }
    }
}
