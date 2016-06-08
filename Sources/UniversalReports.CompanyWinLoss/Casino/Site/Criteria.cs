using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Casino.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Casino-Site-{Source}";
        }
    }
}