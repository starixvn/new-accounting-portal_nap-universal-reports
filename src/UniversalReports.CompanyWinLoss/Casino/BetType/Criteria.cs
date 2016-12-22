using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Casino.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Casino-BetType-{Source}";
        }
    }
}