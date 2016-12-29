using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }
}