using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Universal.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Universal-BetType-{Source}";
        }
    }
}