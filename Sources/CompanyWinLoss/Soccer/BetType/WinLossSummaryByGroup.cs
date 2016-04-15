using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Soccer.BetType
{
    public class WinLossSummaryByBetTypeGroup
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }

        public WinLoss Total { get; set; }
    }
}
