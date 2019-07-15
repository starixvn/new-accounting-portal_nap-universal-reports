using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.OtherSports.NewCricket
{
    public class ChargeCommissionModel
    {
        public List<SiteWinLossSummary> Winloss { get; set; }

        public SiteWinLossSummary Total { get; set; }
    }
}