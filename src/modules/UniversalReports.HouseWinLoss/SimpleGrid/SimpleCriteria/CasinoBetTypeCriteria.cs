using Fanex.Data;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class CasinoBetTypeCriteria : WinLossCriteria
    {
        [SpParam(SqlParamName = "ProductId")]
        public int CasinoProductId { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Casino-BetType-{Source}";
    }
}