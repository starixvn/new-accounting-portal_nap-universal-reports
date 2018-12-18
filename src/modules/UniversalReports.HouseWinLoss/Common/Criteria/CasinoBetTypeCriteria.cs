using Fanex.Data;

namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class CasinoBetTypeCriteria : WinLossCriteria
    {
        [SpParam(SqlParamName = "ProductId")]
        public int CasinoProductId { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Casino-BetType-{Source}";
    }
}