using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    public class WinLossModel
    {
        public List<WinLossSummaryByBetTypeGroup> SiteWinLossSummaries { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }

        public WinLoss MainTotal { get; set; }

        public WinLoss OtherTotal { get; set; }
    }
}
