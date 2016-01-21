using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface CalculationService
    {
        SiteWinLossSummary CalculateGrandTotal(string totalTitle, IEnumerable<RawWinLoss> rawWinLosses);

        WinLoss CalculateTotal(string totalTitle, IEnumerable<RawWinLoss> rawWinLosses);

        IEnumerable<SiteWinLossSummary> CalculateSiteWinLossSummary(IEnumerable<RawWinLoss> rawWinLosses);

        decimal CalculateMargin(decimal turnover, decimal income);

        RawWinLoss CalculateSum(IEnumerable<RawWinLoss> winlosses);

        WinLoss FromRawWinLoss(RawWinLoss rawWinLoss);
    }
}