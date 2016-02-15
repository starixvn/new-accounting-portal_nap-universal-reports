using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.Models
{
    public class SportTypeWinLossModel
    {
        public List<SiteWinLossSummary> Sports { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
