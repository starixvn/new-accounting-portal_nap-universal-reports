using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models.MainReport
{
    public class MainReportWinLoss
    {
        public List<WinLoss> SportsbookDetail { get; set; }

        public ProductWinLoss Sportsbook { get; set; }

        public List<ProductWinLoss> OtherProducts { get; set; }

        public ProductWinLoss GrandTotal { get; set; }
    }
}
