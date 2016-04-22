using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class SportsbookWinLoss
    {
        public List<SiteWinLossSummary> Products { get; set; }

        public List<WinLoss> RM { get; set; } = new List<WinLoss>();
    }
}