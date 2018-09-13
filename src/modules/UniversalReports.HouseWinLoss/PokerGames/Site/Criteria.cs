using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.PokerGames.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = 2;

        public override string GetSettingKey() => $"HouseWinLoss-PokerGames-Site-{Source}";
    }
}