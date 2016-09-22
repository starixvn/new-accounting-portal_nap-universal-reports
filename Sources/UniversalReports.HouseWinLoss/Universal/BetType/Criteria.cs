using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Universal.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public int SportType { get; set; } = 0;

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-Universal-BetType-{Source}";
        }
    }
}