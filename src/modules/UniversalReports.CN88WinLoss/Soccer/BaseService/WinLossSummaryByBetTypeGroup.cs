using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Soccer.BaseService
{
    public class WinLossSummaryByBetTypeGroup
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }

        public WinLoss Total { get; set; }
    }
}