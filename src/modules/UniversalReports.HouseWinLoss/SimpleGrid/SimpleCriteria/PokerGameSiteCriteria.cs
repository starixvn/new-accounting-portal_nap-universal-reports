using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class PokerGameSiteCriteria : WinLossCriteria
    {
        private const int AllLiveAndNonLive = 2;

        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = AllLiveAndNonLive;

        public override string GetSettingKey() => $"HouseWinLoss-PokerGames-Site-{Source}";
    }
}