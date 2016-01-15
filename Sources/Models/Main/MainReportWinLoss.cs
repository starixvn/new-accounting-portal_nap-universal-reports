using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models.Main
{
    public class MainWinLoss
    {
        public List<WinLoss> SportsbookDetail { get; set; }

        public List<SiteWinLoss> Products { get; set; }

        public SiteWinLoss GrandTotal { get; set; }
    }
}
