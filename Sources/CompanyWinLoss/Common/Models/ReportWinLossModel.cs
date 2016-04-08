using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.Models
{
    public class ReportWinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
