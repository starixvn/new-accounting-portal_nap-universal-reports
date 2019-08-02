using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.Sportsbook.OutrightMatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey() => $"CN88WinLoss-Sportsbook-Outright-MatchDetail-{Source}";
    }
}