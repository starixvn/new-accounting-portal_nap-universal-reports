using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-VirtualSports-Racing-MatchDetail-{Source}";
        }
    }
}