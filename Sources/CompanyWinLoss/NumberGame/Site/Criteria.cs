using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.NumberGame.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public bool IsLive { get; set; }

        public string Site { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria
            {
                BetType = BetType,
                IsLive = IsLive,
                Site = Site
            };

            newCriteria.Update(source);

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-NumberGame-Site-{Source}";
        }
    }
}