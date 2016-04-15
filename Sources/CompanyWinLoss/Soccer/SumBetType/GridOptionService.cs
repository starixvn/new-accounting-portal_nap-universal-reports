using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}
