using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ProductWinLoss
    {
        public ProductGroupWinLoss Sportsbook { get; set; }

        public List<WinLoss> RM { get; set; } = new List<WinLoss>();

        public ProductGroupWinLoss NonSportsbook { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}