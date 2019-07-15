using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Products
{
    public class ProductGroupWinLoss
    {
        public List<SiteWinLossSummary> Products { get; set; }

        public SiteWinLossSummary Total { get; set; }

        public bool IsEmpty => Total.IsEmpty;
    }
}