using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class BetTradeBetTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-Bettrade-BetType";
    }
}