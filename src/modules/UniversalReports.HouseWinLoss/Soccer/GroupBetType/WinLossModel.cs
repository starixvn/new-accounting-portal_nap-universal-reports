using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Soccer.BaseService;

namespace UniversalReports.HouseWinLoss.Soccer.GroupBetType
{
    public class WinLossModel : BaseBetTypeWinLossModel
    {
        public List<WinLossSummaryByBetTypeGroup> SiteWinLossSummaries { get; set; }
    }
}