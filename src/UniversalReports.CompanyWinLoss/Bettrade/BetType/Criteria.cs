using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Bettrade.BetType
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Bettrade-BetType-{Source}";
        }
    }
}