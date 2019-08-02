using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.SimpleGrid.SimpleCriteria
{
    public class UniversalSiteCriteria : WinLossCriteria
    {
        private const int AllLiveAndNonLive = 2;

        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = AllLiveAndNonLive;

        public override string GetSettingKey() => $"CN88WinLoss-Universal-Site-{Source}";
    }
}