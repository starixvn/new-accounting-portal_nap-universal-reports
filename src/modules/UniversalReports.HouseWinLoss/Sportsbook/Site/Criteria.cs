using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Sportsbook.Site
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public int IsHedge { get; set; } = Constants.HedgeDefault;

        public bool IsNoDraw { get; set; }

        public int IsSabaSport { get; set; } = Constants.IsSabaSportDefault;

        public override string GetSettingKey()
        {
            const int betBuilderBetType = 38;
            return BetType == betBuilderBetType ? $"HouseWinLoss-BetBuilder-Site-{Source}" : $"HouseWinLoss-Sportsbook-Site-{Source}";
        }
    }
}