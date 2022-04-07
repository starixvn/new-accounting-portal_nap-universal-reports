using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.BetBuilder.BetType
{
    public class BetBuilderBetTypeCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-BetBuilder-BetType";
    }
}