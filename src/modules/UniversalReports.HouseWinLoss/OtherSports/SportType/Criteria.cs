using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.OtherSports.SportType
{
    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public bool IsNoDraw { get; set; } = false;

        public override string GetSettingKey() => $"HouseWinLoss-OtherSports-SportType-LiveStatus-{Source}";
    }
}