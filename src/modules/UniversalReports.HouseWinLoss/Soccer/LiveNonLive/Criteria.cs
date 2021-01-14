using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Soccer.LiveNonLive
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-Soccer-MajorMinor-LiveStatus-{Source}";

        public bool IsNoDraw { get; set; } = false;

        public bool IsSabaSport { get; set; } = false;
    }
}