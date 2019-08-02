using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.OtherSports.LiveNonLive
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"CN88WinLoss-OtherSports-SportType-LiveStatus-{Source}";
    }
}