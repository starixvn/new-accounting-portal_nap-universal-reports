using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class NumberGameBetTypeWinLossSummary
    {
        public List<SiteWinLossSummary> Live { get; set; }

        public SiteWinLossSummary LiveGrandTotal { get; set; }

        public List<SiteWinLossSummary> NonLive { get; set; }

        public SiteWinLossSummary NonLiveGrandTotal { get; set; }
    }
}
