using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Parlay.SiteService
{
    public class SiteParlayModel
    {
        public List<SiteModel> Sites { get; set; }

        public WinLoss Total { get; set; }
    }
}