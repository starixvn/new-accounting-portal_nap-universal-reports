using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    public interface GridOptionsBuilder
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}
