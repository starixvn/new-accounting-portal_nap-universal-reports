using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.Models
{
    public class BasicWinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
