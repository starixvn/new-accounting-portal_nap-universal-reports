using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.Services.Models;
namespace NAP.Reports.CompanyWinLoss.Services
{
    interface ICalculationService
    {
        decimal CalculateMargin(decimal turnover, decimal income);

        WinLoss CalculateTotal(RawWinLoss[] rawWinLosses, string totalTitle);

        WinLoss FromRawWinLoss(RawWinLoss rawWinLoss);
    }
}
