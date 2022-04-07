using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class CasinoSiteCriteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Casino-Site";
    }
}