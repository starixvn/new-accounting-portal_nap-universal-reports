using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Sportsbook.OutrightMatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey()
        {
            return $"HouseWinLoss-Sportsbook-Outright-MatchDetail-{Source}";
        }
    }
}