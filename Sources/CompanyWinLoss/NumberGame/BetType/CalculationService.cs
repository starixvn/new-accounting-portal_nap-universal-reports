using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    public interface CalculationService
    {
        IEnumerable<SiteWinLossSummary> CalculateSiteWinLossSummary(IEnumerable<RawWinLoss> rawWinLosses);

        SiteWinLossSummary CalculateSumWinLossSummary(string totalTile, IEnumerable<RawWinLoss> rawWinLosses);
    }
}