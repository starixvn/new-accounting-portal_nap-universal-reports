using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Products
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