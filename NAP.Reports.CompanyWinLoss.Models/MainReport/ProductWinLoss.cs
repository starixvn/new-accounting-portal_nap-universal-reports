
using System.Collections.Generic;
namespace NAP.Reports.CompanyWinLoss.Models.MainReport
{
    public class ProductWinLoss
    {
        public WinLoss Total { get; set; }

        public List<WinLoss> Products { get; set; }
    }
}
