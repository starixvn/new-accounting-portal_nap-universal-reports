using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Soccer.SumBetType
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }

        public WinLoss MainTotal { get; set; }

        public WinLoss OtherTotal { get; set; }

        public WinLoss HedgeTotal { get; set; }

        public List<WinLoss> RM { get; set; } = new List<WinLoss>();
    }
}
