using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.VirtualSportsBetradar.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-VirtualSportsBetradar-MatchDetail";
    }
}