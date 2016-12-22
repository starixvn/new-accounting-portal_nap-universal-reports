using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.OtherSports.LiveNonLive
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"HouseWinLoss-OtherSports-LiveNonLive-{Source}";
        }
    }
}