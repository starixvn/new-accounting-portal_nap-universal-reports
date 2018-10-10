using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.OutrightMatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Sportsbook-Outright-MatchDetail-{Source}";
    }
}