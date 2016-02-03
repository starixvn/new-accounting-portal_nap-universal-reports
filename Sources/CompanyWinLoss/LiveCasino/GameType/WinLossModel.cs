using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.LiveCasino.GameType
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> GameTypes { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
