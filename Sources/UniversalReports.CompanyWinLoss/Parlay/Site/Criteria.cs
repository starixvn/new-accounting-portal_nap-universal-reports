using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Parlay.Site
{
    public class Criteria : WinLossCriteria
    {
        public string Site { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-SystemParlay-{Source}";
        }
    }
}