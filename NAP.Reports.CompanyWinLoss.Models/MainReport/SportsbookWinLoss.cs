using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models.MainReport
{
    public class SportsbookWinLoss
    {
        public List<WinLoss> Products { get; set; }

        public WinLoss Total { get; set; }
    }
}
