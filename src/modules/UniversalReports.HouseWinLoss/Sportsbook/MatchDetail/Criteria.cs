using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Sportsbook.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public int IsHedge { get; set; } = Constants.HedgeDefault;

        public int IsCorners { get; set; } = Constants.CornersDefault;

        public bool IsNoDraw { get; set; }

        public int IsSabaSport { get; set; } = Constants.IsSabaSportDefault;

        public int PermissionProfileID { get; } = 1;

        public override string GetSettingKey()
        {
            const int betBuilderBetType = 38;
            return BetType == betBuilderBetType ? $"HouseWinLoss-BetBuilder-MatchDetail" : $"HouseWinlossByProducts_LvlN_Sportsbook_MatchDetail";
        }
    }
}