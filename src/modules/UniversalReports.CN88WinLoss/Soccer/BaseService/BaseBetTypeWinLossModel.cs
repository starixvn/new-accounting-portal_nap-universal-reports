using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Soccer.BaseService
{
    public class BaseBetTypeWinLossModel
    {
        protected BaseBetTypeWinLossModel()
        {
        }

        public SiteWinLossSummary GrandTotal { get; set; }

        public WinLoss MainTotal { get; set; }

        public WinLoss OtherTotal { get; set; }

        public WinLoss HedgeTotal { get; set; }

        public List<WinLoss> RM { get; set; } = new List<WinLoss>();
    }
}