using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class BetBuilderBetTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-BetBuilder-BetType-{Source}";
    }
}