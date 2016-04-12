using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.MetricGaming.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public int IsLive { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria();
            newCriteria.Update(source);
            newCriteria.BetType = BetType;
            newCriteria.IsLive = IsLive;

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-MetricGaming-MatchDetail-{Source}";
        }
    }
}