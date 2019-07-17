using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Products
{
    public class ProductWinLoss
    {
        public ProductGroupWinLoss Sportsbook { get; set; }

        public ProductGroupWinLoss NonSportsbook { get; set; }

        public WinLoss GrandTotal { get; set; }

        public bool IsEmpty => GrandTotal.IsEmpty;
    }
}