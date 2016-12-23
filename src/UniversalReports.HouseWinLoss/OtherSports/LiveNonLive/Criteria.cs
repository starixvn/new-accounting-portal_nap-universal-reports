using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.OtherSports.LiveNonLive
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-OtherSports-LiveNonLive-{Source}"; 
    }
}