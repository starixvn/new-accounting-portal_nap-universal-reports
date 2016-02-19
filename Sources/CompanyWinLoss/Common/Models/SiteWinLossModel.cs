using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.Models
{
    public class SiteWinLossModel
    {
        public List<WinLoss> Sites { get; set; }

        public WinLoss Total { get; set; }
    }
}
