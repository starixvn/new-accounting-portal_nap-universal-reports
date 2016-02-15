using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> Live { get; set; }

        public SiteWinLossSummary LiveGrandTotal { get; set; }

        public List<SiteWinLossSummary> NonLive { get; set; }

        public SiteWinLossSummary NonLiveGrandTotal { get; set; }
    }
}
