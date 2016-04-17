using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    public interface GridOptionBuilder
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}
