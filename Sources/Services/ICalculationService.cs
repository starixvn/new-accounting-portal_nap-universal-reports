using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface ICalculationService
    {
        decimal CalculateMargin(decimal turnover, decimal income);

        WinLoss CalculateTotal(string totalTitle, WinLoss credit, WinLoss deposit);

        WinLoss FromRawWinLoss(RawWinLoss rawWinLoss);

        WinLoss CalculateSum(string totalTitle, IEnumerable<WinLoss> winlosses);

        WinLoss CreateEmptyWinLoss(string title);

        IEnumerable<WinLoss> CalculateSum(IEnumerable<IEnumerable<WinLoss>> twoDimensionWinLosses);
    }
}
