using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class SiteWinLoss
    {
        public List<WinLoss> Sites { get; set; }

        public WinLoss Total { get; set; }
    }
}
