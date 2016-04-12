using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class NoneSportsbookWinloss
    {
        public List<SiteWinLossSummary> Products { get; set; }

        public SiteWinLossSummary Total { get; set; }
    }
}
