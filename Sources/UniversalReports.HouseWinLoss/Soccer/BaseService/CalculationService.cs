using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Soccer.BaseService
{
    public interface CalculationService : Common.Services.CalculationService
    {
        List<WinLossSummaryByBetTypeGroup> CalculateSiteWinLossSummaryGroups(IEnumerable<WinLossRaw> rawWinLosses);

        WinLoss CalculateMainSumWinLossSummary(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses);

        WinLoss CalculateOtherSumWinLossSummary(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses);

        WinLoss CalculateHedgeSumWinLossSummary(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses);
    }
}
