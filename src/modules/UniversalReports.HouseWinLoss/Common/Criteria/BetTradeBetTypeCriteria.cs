
namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class BetTradeBetTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-Bettrade-BetType-{Source}";
    }
}