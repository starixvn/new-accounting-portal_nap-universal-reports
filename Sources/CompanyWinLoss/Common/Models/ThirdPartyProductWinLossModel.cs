using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.Models
{
    public class ThirdPartyProductWinLossModel
    {
        public List<SiteWinLossSummary> Products { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}