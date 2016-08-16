using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Universal.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-Universal-Site-{Source}";
        }
    }
}