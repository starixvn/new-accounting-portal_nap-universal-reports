using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class GroupOfSiteWinLoss
    {
        public List<SiteWinLoss> Live { get; set; }

        public SiteWinLoss LiveGrandTotal { get; set; }

        public List<SiteWinLoss> NonLive { get; set; }

        public SiteWinLoss NonLiveGrandTotal { get; set; }
    }
}
