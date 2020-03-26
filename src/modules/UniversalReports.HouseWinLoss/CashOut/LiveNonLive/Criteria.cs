using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.CashOut.LiveNonLive
{
    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey() => $"HouseWinLoss-CashOut-BetType-LiveStatus-{Source}";
    }
}