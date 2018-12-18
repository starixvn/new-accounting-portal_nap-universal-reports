namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class UniversalSportTypeCriteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Universal-SportType-{Source}";
    }
}