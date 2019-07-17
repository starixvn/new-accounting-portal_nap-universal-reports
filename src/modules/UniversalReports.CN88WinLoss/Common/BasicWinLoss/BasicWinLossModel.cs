using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Common.BasicWinLoss
{
    public class BasicWinLossModel
    {
        public List<WinLoss> WinLosses { get; set; }

        public WinLoss GrandTotal { get; set; }
    }
}