using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ProductWinLoss
    {
        public SportsbookWinLoss SportsbookProducts { get; set; }

        public NoneSportsbookWinloss NoneSportsbookProducts { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}