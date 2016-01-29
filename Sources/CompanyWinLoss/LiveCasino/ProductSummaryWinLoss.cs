using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.LiveCasino
{
    public class ProductSummaryWinLoss
    {
        public List<SiteWinLossSummary> Products { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
