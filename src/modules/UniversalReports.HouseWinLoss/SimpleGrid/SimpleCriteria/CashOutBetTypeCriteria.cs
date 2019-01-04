using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class CashOutBetTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-CashOut-BetType-{Source}";
    }
}