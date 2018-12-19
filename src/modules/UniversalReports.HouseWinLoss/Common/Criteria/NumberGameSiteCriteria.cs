namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class NumberGameSiteCriteria : WinLossCriteria
    {
        public int LeagueId { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Universal-Site-{Source}";
    }
}