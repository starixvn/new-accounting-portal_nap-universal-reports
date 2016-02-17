using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.LiveCasino.BetType
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> BetTypes { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
