using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.NumberGame.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public bool IsLive { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-NumberGame-MatchDetail-{Source}"; 
    }
}