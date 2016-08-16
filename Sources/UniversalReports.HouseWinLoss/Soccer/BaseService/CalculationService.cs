using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Soccer.BaseService
{
    public interface CalculationService : Common.Services.CalculationService
    {
        List<WinLossSummaryByBetTypeGroup> CalculateSiteWinLossSummaryGroups(IEnumerable<RawWinLoss> rawWinLosses);

        WinLoss CalculateMainSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses);

        WinLoss CalculateOtherSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses);

        WinLoss CalculateHedgeSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses);
    }
}
