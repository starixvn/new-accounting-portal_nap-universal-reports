using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Soccer.SumBetType
{
    public class SumBetTypeCriteria : WinLossCriteria
    {
        public bool IsMajor { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"HouseWinLoss-Soccer-BetType-{Source}";

        public bool IsNoDraw { get; set; } = false;

        public bool IsSabaSport { get; set; } = false;
    }
}