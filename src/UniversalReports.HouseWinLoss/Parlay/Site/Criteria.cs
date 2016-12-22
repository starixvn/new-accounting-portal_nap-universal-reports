using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Parlay.Site
{
    public class Criteria : WinLossCriteria
    {
        public string Site { get; set; }

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-SystemParlay-{Source}";
        }
    }
}