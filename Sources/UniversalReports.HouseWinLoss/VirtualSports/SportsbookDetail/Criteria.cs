using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.VirtualSports.SportsbookDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-VirtualSports-Sportsbook-MatchDetail-{Source}";
        }
    }
}