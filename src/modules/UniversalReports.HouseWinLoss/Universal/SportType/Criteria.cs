using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Universal.SportType
{
    public class Criteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Universal-SportType-{Source}";
    }
}