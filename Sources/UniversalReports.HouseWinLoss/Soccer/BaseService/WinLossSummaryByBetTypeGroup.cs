using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Soccer.BaseService
{
    public class WinLossSummaryByBetTypeGroup
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }

        public WinLoss Total { get; set; }
    }
}
