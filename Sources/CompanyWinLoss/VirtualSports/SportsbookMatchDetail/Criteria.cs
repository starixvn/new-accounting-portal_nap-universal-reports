using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria();
            newCriteria.Update(source);
            newCriteria.SportType = SportType;
            newCriteria.BetType = BetType;

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-VirtualSports-Sportsbook-MatchDetail-{Source}";
        }
    }
}
