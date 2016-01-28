using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.Models
{
    public class SiteWinLoss
    {
        public List<WinLoss> Sites { get; set; }

        public WinLoss Total { get; set; }
    }
}
