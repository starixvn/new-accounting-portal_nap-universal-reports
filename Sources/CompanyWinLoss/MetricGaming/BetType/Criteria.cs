using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.MetricGaming.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria();
            newCriteria.Update(source);
            newCriteria.IsLive = IsLive;
            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-MetricGaming-BetType-{Source}";
        }
    }
}
