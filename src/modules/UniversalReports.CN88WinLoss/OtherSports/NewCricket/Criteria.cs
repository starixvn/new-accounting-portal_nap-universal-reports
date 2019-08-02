using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Configuration;

namespace UniversalReports.CN88WinLoss.OtherSports.NewCricket
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"CN88WinLoss-OtherSports-BetType-{Source}";
    }
}