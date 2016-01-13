using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models.MainReport
{
    public class MainReportWinLoss
    {
        public List<WinLoss> SportsbookDetail { get; set; }

        public List<ProductWinLoss> Products { get; set; }

        public ProductWinLoss GrandTotal { get; set; }
    }
}
