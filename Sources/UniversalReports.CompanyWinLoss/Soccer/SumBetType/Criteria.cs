using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
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
