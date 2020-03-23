using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.CashOut.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"HouseWinLoss-CashOut-MatchDetail-{Source}";
    }
}