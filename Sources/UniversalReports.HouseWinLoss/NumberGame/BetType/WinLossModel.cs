using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.NumberGame.BetType
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> Live { get; set; }

        public SiteWinLossSummary LiveGrandTotal { get; set; }

        public List<SiteWinLossSummary> NonLive { get; set; }

        public SiteWinLossSummary NonLiveGrandTotal { get; set; }
    }
}