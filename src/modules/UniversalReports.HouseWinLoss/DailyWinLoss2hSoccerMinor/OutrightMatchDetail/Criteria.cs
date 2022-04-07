using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.OutrightMatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int IsSabaSport { get; set; } = Constants.IsAllSportDefault;

        public override string GetSettingKey() => $"HouseWinLoss-Sportsbook-Outright-MatchDetail";
    }
}