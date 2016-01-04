using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models.MainReport
{
    public class MainReportWinLoss
    {
        public SportsbookWinLoss SportsbookWinLoss { get; set; }

        public List<OtherProductWinLoss> OtherProductWinLoss { get; set; }

        public List<WinLoss> Total { get; set; }
    }
}
