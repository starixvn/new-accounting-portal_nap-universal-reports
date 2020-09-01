using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class NonSportsRNGBetTypeCriteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-NonSportsRNG-BetType-{Source}";
    }
}