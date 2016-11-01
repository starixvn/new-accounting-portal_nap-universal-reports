using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.OtherSports.NewCricket
{
    public class ChargeCommissionModel
    {
        public List<SiteWinLossSummary> Winloss { get; set; }

        public SiteWinLossSummary Total { get; set; }
    }
}