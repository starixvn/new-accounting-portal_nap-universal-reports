using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.ColossusBet.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public bool IsFreePlay { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-ColossusBet-Site-{Source}";
    }
}