using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class SportsbookWinLoss
    {
        public List<SiteWinLossSummary> Products { set; get; }

        public List<WinLoss> RM { set; get; }
    }
}