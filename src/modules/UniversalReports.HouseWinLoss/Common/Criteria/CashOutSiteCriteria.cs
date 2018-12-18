namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class CashOutSiteCriteria : WinLossCriteria
    {
        public string Site { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-CashOut-Site-{Source}";
    }
}