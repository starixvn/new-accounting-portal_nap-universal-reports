using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class LiveCasinoProductSummaryWinLoss
    {
        public List<SiteWinLossSummary> LiveCasinoProduct { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
