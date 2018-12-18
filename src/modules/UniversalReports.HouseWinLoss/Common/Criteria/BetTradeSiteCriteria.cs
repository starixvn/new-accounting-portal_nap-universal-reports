namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class BetTradeSiteCriteria : WinLossCriteria
    {
        public string Site { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Bettrade-Site-{Source}";
    }
}