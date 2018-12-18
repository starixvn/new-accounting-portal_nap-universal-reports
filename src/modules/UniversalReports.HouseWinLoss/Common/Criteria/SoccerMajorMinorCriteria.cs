using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class SoccerMajorMinorCriteria : WinLossCriteria
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"HouseWinLoss-Soccer-MajorMinor-LiveStatus-{Source}";
    }
}