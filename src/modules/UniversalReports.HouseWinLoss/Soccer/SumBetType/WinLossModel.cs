using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Soccer.BaseService;

namespace UniversalReports.HouseWinLoss.Soccer.SumBetType
{
    public class WinLossModel : BaseBetTypeWinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }
    }
}