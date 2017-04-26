using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.FishingWorld.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public int SportType { get; set; }

        public int IsLive { get; set; } = 2;

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-FishingWorld-BetType-{Source}";
        }
    }
}