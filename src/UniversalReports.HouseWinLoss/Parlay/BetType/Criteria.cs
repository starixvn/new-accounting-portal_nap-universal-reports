using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Parlay.BetType
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-Parlay-{Source}"; 
    }
}