namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class PokerGamesBetTypeCriteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public int SportType { get; set; }

        public int IsLive { get; set; } = 2;

        public override string GetSettingKey() => $"HouseWinLoss-PokerGames-BetType-{Source}";
    }
}