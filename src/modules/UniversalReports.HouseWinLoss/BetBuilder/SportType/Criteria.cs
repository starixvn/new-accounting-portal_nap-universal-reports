using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.BetBuilder.SportType
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinLoss-BetBuilder-SportType";
    }
}