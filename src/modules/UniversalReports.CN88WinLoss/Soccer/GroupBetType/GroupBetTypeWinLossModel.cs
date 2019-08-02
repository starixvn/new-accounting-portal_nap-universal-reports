using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Soccer.BaseService;

namespace UniversalReports.CN88WinLoss.Soccer.GroupBetType
{
    public class GroupBetTypeWinLossModel : BaseBetTypeWinLossModel
    {
        public List<WinLossSummaryByBetTypeGroup> WinLossSummaries { get; set; }
    }
}