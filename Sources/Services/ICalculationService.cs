using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface ICalculationService
    {
        decimal CalculateMargin(decimal turnover, decimal income);

        WinLoss FromRawWinLoss(RawWinLoss rawWinLoss);

        RawWinLoss CalculateSum(IEnumerable<RawWinLoss> winlosses);

        IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources);

        WinLoss CalculateTotal(string totalTitle, WinLoss credit, WinLoss deposit);
    }
}
