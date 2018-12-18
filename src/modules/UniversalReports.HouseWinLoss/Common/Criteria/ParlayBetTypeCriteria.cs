namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class ParlayBetTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-Parlay-{Source}";
    }
}