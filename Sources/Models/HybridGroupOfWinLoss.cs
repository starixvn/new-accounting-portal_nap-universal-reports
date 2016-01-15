using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class HybridGroupOfWinLoss
    {
        public List<GroupOfWinLoss> WinLosses { get; set; }

        public WinLoss GrandTotal { get; set; }
    }
}
