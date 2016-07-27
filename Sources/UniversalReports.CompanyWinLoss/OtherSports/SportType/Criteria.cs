using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Configuration;

namespace UniversalReports.CompanyWinLoss.OtherSports.SportType
{
    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-OtherSports-SportType-{Source}";
        }
    }
}