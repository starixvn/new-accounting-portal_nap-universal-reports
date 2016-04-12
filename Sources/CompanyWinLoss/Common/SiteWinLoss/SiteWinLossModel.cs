using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.SiteWinLoss
{
    public class SiteWinLossModel
    {
        public List<WinLoss> Sites { get; set; }

        public WinLoss Total { get; set; }
    }
}