using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Configuration;

namespace UniversalReports.CN88WinLoss.Soccer.GroupBetType
{
    public class GroupBetTypeCriteria : WinLossCriteria
    {
        public bool IsMajor { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"CN88WinLoss-Soccer-BetType-{Source}";
    }
}