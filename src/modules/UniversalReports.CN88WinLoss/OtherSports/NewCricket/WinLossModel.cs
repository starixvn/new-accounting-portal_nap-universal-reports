using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.OtherSports.NewCricket
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossNonChargedCom { get; set; }

        public ChargeCommissionModel SiteWinLossChargedCom { get; set; }

        public List<WinLoss> RM { get; set; } = new List<WinLoss>();

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}