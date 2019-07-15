using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Products
{
    public class ProductWinLoss
    {
        public ProductGroupWinLoss Sportsbook { get; set; }

        public List<WinLoss> RM { get; set; } = new List<WinLoss>();

        public ProductGroupWinLoss NonSportsbook { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }

        public bool IsEmpty => GrandTotal.Credit.IsEmpty
                               && GrandTotal.Deposit.IsEmpty;
    }
}