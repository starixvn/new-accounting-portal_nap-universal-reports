using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Products
{
    public class ProductGroupWinLoss
    {
        public List<SiteWinLossSummary> Products { get; set; }

        public SiteWinLossSummary Total { get; set; }

        public bool IsEmpty => Total.IsEmpty;
    }
}