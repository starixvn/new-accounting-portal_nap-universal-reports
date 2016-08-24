using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.NumberGame.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public bool IsLive { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-NumberGame-MatchDetail-{Source}";
        }
    }
}