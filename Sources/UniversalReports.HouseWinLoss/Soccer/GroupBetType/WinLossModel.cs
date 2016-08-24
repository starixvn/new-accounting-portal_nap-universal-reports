using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Soccer.BaseService;

namespace UniversalReports.HouseWinLoss.Soccer.GroupBetType
{
    public class WinLossModel
    {
        public List<WinLossSummaryByBetTypeGroup> SiteWinLossSummaries { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }

        public WinLoss MainTotal { get; set; }

        public WinLoss OtherTotal { get; set; }

        public WinLoss HedgeTotal { get; set; }

        public List<WinLoss> RM { get; set; } = new List<WinLoss>();
    }
}
