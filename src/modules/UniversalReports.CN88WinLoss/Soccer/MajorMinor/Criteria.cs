using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Configuration;

namespace UniversalReports.CN88WinLoss.Soccer.MajorMinor
{
    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"CN88WinLoss-Soccer-MajorMinor-LiveStatus-{Source}";
    }
}