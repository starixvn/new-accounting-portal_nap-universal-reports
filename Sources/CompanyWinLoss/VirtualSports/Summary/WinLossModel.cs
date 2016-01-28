using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.VirtualSports.Summary
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> Sports { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
