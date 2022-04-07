using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class CashOutSiteCriteria : WinLossCriteria
    {
        public string Site { get; set; }

        public int IsLive { get; set; }

        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-CashOut-Site";
    }
}