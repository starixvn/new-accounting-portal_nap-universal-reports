using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.OtherSports.NewCricket
{
    public class ChargeCommissionModel
    {
        public List<SiteWinLossSummary> Winloss { get; set; }

        public SiteWinLossSummary Total { get; set; }
    }
}
