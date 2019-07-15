using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.VirtualSportsBetradar.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public override string GetSettingKey() => $"CN88WinLoss-VirtualSportsBetradar-MatchDetail-{Source}";
    }
}