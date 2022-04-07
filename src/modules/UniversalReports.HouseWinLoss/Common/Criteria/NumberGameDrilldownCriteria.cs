namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class NumberGameDrilldownCriteria : WinLossCriteria
    {
        public bool IsNoDraw { get; set; }

        public int PermissionProfileID { get; } = 1;

        public int SportType { get; set; }

        public int LeagueId { get; set; }

        public int Bettype { get; set; }

        public string SiteType { get; set; }

        public override string GetSettingKey() => $"HouseWinlossByProducts_LvlN_NumberGame";
    }
}
