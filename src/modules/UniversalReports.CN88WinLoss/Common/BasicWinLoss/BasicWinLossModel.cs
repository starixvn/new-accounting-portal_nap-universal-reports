using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Common.BasicWinLoss
{
    public class BasicWinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }

        public List<WinLoss> RM { get; set; } = new List<WinLoss>();

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}