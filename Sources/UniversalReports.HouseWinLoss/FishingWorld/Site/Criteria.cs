using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.FishingWorld.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = 2;

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-FishingWorld-Site-{Source}";
        }
    }
}