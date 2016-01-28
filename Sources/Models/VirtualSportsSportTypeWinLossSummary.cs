using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class VirtualSportsSportTypeWinLossSummary
    {
        public List<SiteWinLossSummary> Sports { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
