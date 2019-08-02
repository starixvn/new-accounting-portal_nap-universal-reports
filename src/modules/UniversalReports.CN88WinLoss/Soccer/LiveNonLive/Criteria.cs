using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.Soccer.LiveNonLive
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"CN88WinLoss-Soccer-MajorMinor-LiveStatus-{Source}";
    }
}