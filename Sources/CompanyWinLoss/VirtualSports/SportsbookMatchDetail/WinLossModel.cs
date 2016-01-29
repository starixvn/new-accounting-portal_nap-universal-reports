using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail
{
    public class WinLossModel
    {
        public List<WinLoss> Matches { get; set; }

        public WinLoss Total { get; set; }
    }
}
