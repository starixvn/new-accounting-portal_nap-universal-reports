using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Casino.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-Casino-Site-{Source}";
        }
    }
}