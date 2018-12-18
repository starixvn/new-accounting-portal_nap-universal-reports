namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class SoccerMinor2hSportTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-Soccer-Minor-SportType-{Source}";
    }
}