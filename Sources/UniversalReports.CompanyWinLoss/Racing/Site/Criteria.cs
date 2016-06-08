using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Racing.Site
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Racing-Site-{Source}";
        }
    }
}