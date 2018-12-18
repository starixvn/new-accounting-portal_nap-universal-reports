namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class VirtualSportsBetradarBetTypeCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-VirtualSportsBetradar-BetType-{Source}";
    }
}