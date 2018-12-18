namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class CashOutBetTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-CashOut-BetType-{Source}";
    }
}