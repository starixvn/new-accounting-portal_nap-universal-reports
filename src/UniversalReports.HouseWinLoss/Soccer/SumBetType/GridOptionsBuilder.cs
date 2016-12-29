using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Soccer.SumBetType
{
    public interface GridOptionsBuilder
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}