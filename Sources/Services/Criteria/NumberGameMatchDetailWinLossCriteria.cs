namespace NAP.Reports.CompanyWinLoss.Services.Criteria
{
    public class NumberGameMatchDetailWinLossCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public bool IsLive { get; set; }
    }
}
