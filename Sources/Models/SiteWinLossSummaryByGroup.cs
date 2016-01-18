using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class SiteWinLossSummaryByGroup
    {
        public List<SiteWinLossSummary> SportTypes { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
