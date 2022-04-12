using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Products
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"HouseWinlossByProducts_Lvl1";

        public bool IsNoDraw { get; set; }

        public int PermissionProfileID { get; set; }
    }
}