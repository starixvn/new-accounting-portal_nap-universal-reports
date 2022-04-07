using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class BetTradeSiteCriteria : WinLossCriteria
    {
        public string Site { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Bettrade-Site";
    }
}