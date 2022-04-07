using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class CasinoProductCriteria : WinLossCriteria
    {
        public int CasinoType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Casino-Product";
    }
}