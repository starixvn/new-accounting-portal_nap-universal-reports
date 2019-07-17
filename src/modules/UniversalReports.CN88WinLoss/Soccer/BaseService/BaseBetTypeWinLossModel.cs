using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Soccer.BaseService
{
    public class BaseBetTypeWinLossModel
    {
        protected BaseBetTypeWinLossModel()
        {
        }

        public WinLoss GrandTotal { get; set; }

        public WinLoss MainTotal { get; set; }

        public WinLoss OtherTotal { get; set; }
    }
}