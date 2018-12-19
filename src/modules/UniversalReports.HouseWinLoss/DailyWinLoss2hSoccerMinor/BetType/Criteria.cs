using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Soccer-Minor-BetType-{Source}";
    }
}