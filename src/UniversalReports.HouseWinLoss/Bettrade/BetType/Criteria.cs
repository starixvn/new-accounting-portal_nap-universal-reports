using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Bettrade.BetType
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"HouseWinLoss-Bettrade-BetType-{Source}";
        }
    }
}