using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.NumberGame.Site
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public bool IsLive { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-NumberGame-Site-{Source}";
        }
    }
}