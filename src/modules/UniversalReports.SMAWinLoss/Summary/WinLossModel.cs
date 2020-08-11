using System.Collections.Generic;

namespace UniversalReports.SMAWinLoss.Summary
{
    public class WinLossModel
    {
        public List<UsernameWinLoss> UsernameWinLosses { get; set; }

        public List<UsernameWinLoss> Total { get; set; }

        public int TotalItems { get; set; }
    }
}