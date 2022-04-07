using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria
{
    public class ColossusSiteCriteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public bool IsFreePlay { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-ColossusBet-Site";
    }
}