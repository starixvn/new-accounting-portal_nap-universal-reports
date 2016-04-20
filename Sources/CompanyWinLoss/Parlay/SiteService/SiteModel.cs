using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Parlay.SiteService
{
    public class SiteModel
    {
        public List<WinLoss> Sites { get; set; }

        public WinLoss Total { get; set; }
    }
}