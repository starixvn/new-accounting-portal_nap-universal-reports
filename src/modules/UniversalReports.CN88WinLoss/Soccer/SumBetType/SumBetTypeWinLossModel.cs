using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;
using UniversalReports.CN88WinLoss.Soccer.BaseService;

namespace UniversalReports.CN88WinLoss.Soccer.SumBetType
{
    public class SumBetTypeWinLossModel : BaseBetTypeWinLossModel
    {
        public List<SiteWinLossSummary> SiteWinLossSummaries { get; set; }
    }
}