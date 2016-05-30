using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ProductGroupWinLoss
    {
        public List<SiteWinLossSummary> Products { get; set; }

        public SiteWinLossSummary Total { get; set; }
    }
}