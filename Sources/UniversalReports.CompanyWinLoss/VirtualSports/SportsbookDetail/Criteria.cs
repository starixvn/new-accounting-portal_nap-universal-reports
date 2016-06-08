using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-VirtualSports-Sportsbook-MatchDetail-{Source}";
        }
    }
}