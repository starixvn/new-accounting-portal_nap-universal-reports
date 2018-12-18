namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class RacingSportTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-Racing-SportType-{Source}";
    }
}