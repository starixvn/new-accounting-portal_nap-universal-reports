namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class PokerGameSiteCriteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = 2;

        public override string GetSettingKey() => $"HouseWinLoss-PokerGames-Site-{Source}";
    }
}