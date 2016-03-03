using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.Models
{
    public class SiteWinLossSummaryByGroup
    {
        public List<SiteWinLossSummary> SportTypes { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}