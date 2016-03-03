using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.Models
{
    public class BetTypeWinLossModel
    {
        public List<SiteWinLossSummary> BetTypes { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}