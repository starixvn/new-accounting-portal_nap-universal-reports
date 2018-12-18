namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class ColossusBetTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-ColossusBet-BetType-{Source}";
    }
}