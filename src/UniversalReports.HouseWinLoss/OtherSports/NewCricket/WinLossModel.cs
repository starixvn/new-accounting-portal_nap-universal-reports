using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.OtherSports.NewCricket
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossNonChargedCom { get; set; }

        public ChargeCommissionModel SiteWinLossChargedCom { get; set; }

        public List<WinLoss> RM { get; set; } = new List<WinLoss>();

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}