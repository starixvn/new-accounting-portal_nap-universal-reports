using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Sportsbook.OutrightMatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Sportsbook-Outright-MatchDetail-{Source}";
        }
    }
}