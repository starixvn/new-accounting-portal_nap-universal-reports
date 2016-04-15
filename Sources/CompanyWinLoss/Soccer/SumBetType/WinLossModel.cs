using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }

        public WinLoss MainTotal { get; set; }

        public WinLoss OtherTotal { get; set; }

        public List<WinLoss> RM { get; set; }
    }
}
