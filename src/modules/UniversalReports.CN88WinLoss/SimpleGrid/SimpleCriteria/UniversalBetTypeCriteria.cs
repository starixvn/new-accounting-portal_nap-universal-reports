using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.SimpleGrid.SimpleCriteria
{
    public class UniversalBetTypeCriteria : WinLossCriteria
    {
        private const int AllLiveAndNonLive = 2;

        public int ProductId { get; set; }

        public int SportType { get; set; }

        public int IsLive { get; set; } = AllLiveAndNonLive;

        public override string GetSettingKey() => $"CN88WinLoss-Universal-BetType-{Source}";

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