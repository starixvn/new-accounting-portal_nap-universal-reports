using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class NoneSportsbookWinloss
    {
        public List<SiteWinLossSummary> Products { set; get; }

        public SiteWinLossSummary Total { set; get; }
    }
}
