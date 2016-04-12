using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Soccer.MajorOrMinorBetTypes
{
    public interface CalculationService
    {
        WinLoss FromRawWinLossByRowName(RawWinLoss rawWinLoss);

        WinLoss FromRawWinLossByGroupName(RawWinLoss rawWinLoss);

        WinLoss CalculateMainSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses);
        WinLoss CalculateOtherSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses);

        SiteWinLossSummary CalculateSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses);

        WinLoss CalculateSumWinLoss(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses);

        IEnumerable<WinLossSummaryByBetTypeGroup> CalculateSiteWinLossSummary(IEnumerable<RawWinLoss> rawWinLosses);

        decimal CalculateMargin(decimal turnover, decimal income);

        WinLoss CreateEmptyWinLoss(int id, string name);
    }
}
