using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.OtherSports.NewCricket
{
    public class WinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossNonChargedCom { get; set; }

        public ChargeCommissionModel SiteWinLossChargedCom { get; set; }

        public List<WinLoss> RM { get; set; } = new List<WinLoss>();

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
