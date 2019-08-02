using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.Soccer.BetType
{
    public class BetBuilderBetTypeCriteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"CN88WinLoss-BetBuilder-BetType-{Source}";
    }
}