namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class VirtualSportsSportTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-VirtualSports-SportType-{Source}";
    }
}