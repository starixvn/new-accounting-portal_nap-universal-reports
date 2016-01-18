using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class ProductWinLoss
    {
        public List<WinLoss> SportsbookDetail { get; set; }

        public List<SiteWinLossSummary> Products { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
