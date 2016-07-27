using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Configuration;

namespace UniversalReports.CompanyWinLoss.Soccer.BetType
{
    public class Criteria : WinLossCriteria
    {
        public bool IsMajor { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Soccer-BetType-{Source}";
        }
    }
}
