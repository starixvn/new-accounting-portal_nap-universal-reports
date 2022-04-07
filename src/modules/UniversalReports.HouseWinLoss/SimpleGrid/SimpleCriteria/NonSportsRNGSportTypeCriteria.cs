using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class NonSportsRNGSportTypeCriteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-NonSportsRNG-SportType";
    }
}