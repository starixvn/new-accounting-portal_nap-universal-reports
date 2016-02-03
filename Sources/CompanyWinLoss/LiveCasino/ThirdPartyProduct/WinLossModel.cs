using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> Products { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
