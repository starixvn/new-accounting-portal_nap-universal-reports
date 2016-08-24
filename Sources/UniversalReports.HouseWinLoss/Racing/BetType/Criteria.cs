using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Racing.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-Racing-BetType-{Source}";
        }
    }
}