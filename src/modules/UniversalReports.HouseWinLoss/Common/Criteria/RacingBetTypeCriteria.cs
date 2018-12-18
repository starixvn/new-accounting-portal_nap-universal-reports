namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class RacingBetTypeCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Racing-BetType-{Source}";
    }
}