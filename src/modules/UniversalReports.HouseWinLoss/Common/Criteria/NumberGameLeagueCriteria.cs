namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class NumberGameLeagueCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Universal-BetType-{Source}";
    }
}