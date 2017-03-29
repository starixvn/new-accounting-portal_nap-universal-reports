using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Parlay.Site
{
    public class SiteParlayModel
    {
        public List<SiteModel> Sites { get; set; }

        public WinLoss Total { get; set; }
    }
}