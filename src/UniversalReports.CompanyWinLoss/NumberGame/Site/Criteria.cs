using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.NumberGame.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public bool IsLive { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-NumberGame-Site-{Source}";
        }
    }
}