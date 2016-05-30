using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.MetricGaming.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria { IsLive = IsLive };
            newCriteria.Update(source);

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-MetricGaming-BetType-{Source}";
        }
    }
}
