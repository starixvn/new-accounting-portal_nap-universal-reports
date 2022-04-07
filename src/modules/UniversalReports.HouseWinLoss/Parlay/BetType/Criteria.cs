using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Parlay.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int AliasProductID { get; set; }

        public int PermissionProfileID { get; } = 1;

        public bool IsNoDraw { get; set; }

        public override string GetSettingKey() => $"HouseWinlossByProducts_Lvl2";
    }
}