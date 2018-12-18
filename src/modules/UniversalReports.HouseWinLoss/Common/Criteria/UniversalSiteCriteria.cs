namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class UniversalSiteCriteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public int IsLive { get; set; } = 2;

        public override string GetSettingKey() => $"HouseWinLoss-Universal-Site-{Source}";
    }
}