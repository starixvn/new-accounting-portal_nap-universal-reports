using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.OtherSports.LiveNonLive
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-OtherSports-LiveNonLive-{Source}";
        }
    }
}
