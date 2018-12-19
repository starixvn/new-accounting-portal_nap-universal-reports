namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class NumberGameBetTypeCriteria : WinLossCriteria
    {
        public int LeagueId { get; set; }

        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-NumberGame-BetType-{Source}";
    }
}