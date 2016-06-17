using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.OtherSports.NewCricket
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int IsLive { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-OtherSports-BetType-{Source}";
        }
    }
}
