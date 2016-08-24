using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Casino.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-Casino-BetType-{Source}";
        }
    }
}