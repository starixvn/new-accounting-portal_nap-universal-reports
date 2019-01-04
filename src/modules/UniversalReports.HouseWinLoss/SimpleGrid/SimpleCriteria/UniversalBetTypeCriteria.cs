using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class UniversalBetTypeCriteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public int SportType { get; set; }

        public int IsLive { get; set; } = 2;

        public override string GetSettingKey() => $"HouseWinLoss-Universal-BetType-{Source}";

        public UniversalBetTypeCriteria Clone()
        {
            return new UniversalBetTypeCriteria
            {
                ProductId = ProductId,
                SportType = SportType,
                IsLive = IsLive,
                StartDate = StartDate,
                EndDate = EndDate,
                NormalMode = NormalMode,
                Source = Source
            };
        }
    }
}