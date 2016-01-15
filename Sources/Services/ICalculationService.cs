using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface ICalculationService
    {
        SiteWinLoss CalculateGrandTotal(IEnumerable<RawWinLoss> rawWinLosses);

        IEnumerable<SiteWinLoss> CalculateGroupWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        decimal CalculateMargin(decimal turnover, decimal income);

        RawWinLoss CalculateSum(IEnumerable<RawWinLoss> winlosses);

        IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources);

        WinLoss CalculateTotal(string totalTitle, WinLoss credit, WinLoss deposit);

        WinLoss FromRawWinLoss(RawWinLoss rawWinLoss);
    }
}