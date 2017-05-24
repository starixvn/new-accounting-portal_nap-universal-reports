using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Products
{
    public class ProductGroupWinLoss
    {
        public List<SiteWinLossSummary> Products { get; set; }

        public SiteWinLossSummary Total { get; set; }

        public bool IsEmpty => Total.Credit.RealTurnover == 0
                               && Total.Credit.VirtualTurnover == 0
                               && Total.Deposit.RealTurnover == 0
                        && Total.Deposit.VirtualTurnover == 0
                        && Total.Credit.MemberWinLoss == 0
                        && Total.Deposit.MemberWinLoss == 0
                        && Total.Credit.SMAWinLoss == 0
                        && Total.Deposit.SMAWinLoss == 0
            && Total.Credit.RealIncome == 0
                        && Total.Deposit.VirtualIncome == 0;
    }
}