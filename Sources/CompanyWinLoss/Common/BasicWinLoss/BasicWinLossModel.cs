using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.BasicWinLoss
{
    public class BasicWinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
