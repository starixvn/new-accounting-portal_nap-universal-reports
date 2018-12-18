namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class CasinoProductCriteria : WinLossCriteria
    {
        public int CasinoType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Casino-Product-{Source}";
    }
}