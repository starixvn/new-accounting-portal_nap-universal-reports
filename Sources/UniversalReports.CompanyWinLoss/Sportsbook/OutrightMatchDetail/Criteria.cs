using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Sportsbook.OutrightMatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria { SportType = SportType };
            newCriteria.Update(source);

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Sportsbook-Outright-MatchDetail-{Source}";
        }
    }
}