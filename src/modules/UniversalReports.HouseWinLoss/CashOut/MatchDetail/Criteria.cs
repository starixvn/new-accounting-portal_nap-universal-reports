using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.CashOut.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-CashOut-MatchDetail-{Source}";
    }
}