namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class VirtualSportsBetradarSportTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-VirtualSportsBetradar-SportType-{Source}";
    }
}