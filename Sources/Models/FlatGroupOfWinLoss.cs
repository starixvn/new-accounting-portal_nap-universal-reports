using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class FlatGroupOfWinLoss
    {
        public List<WinLoss> WinLosses { get; set; }

        public WinLoss GrandTotal { get; set; }
    }
}
