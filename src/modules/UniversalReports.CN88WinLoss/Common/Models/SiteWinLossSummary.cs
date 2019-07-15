namespace UniversalReports.CN88WinLoss.Common.Models
{
    public class SiteWinLossSummary
    {
        public WinLoss Total { get; set; }

        public WinLoss Credit { get; set; }

        public WinLoss Deposit { get; set; }

        public bool IsEmpty => Total.IsEmpty && Credit.IsEmpty && Deposit.IsEmpty;
    }
}