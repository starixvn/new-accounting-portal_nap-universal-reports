using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Soccer.BaseService;

namespace UniversalReports.HouseWinLoss.Soccer.GroupBetType
{
    public class GroupBetTypeWinLossModel : BaseBetTypeWinLossModel
    {
        public List<WinLossSummaryByBetTypeGroup> SiteWinLossSummaries { get; set; }
    }
}