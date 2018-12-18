namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class VirtualSportsBetTypeCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-VirtualSports-BetType-{Source}";
    }
}