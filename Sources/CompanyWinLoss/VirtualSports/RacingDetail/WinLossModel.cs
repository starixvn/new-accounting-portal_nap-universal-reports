using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail
{
    public class WinLossModel
    {
        public List<WinLoss> Matches { get; set; }

        public WinLoss Total { get; set; }
    }
}
