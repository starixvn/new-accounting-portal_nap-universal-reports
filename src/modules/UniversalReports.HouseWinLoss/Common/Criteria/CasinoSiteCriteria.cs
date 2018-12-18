namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class CasinoSiteCriteria : WinLossCriteria
    {
        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Casino-Site-{Source}";
    }
}