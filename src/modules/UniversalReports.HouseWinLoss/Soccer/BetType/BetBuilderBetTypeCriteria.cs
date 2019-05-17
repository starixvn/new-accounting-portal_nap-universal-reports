using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Soccer.BetType
{
    public class BetBuilderBetTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-BetBuilder-BetType-{Source}";
    }
}