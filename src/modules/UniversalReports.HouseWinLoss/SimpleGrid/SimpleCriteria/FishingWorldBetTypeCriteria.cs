using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class FishingWorldBetTypeCriteria : WinLossCriteria
    {
        private const int AllLiveAndNonLive = 2;

        public int ProductId { get; set; }

        public int SportType { get; set; }

        public int IsLive { get; set; } = AllLiveAndNonLive;

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-FishingWorld-BetType-{Source}";
        }
    }
}