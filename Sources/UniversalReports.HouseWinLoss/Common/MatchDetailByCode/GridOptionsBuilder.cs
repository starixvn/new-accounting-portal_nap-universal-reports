using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Common.MatchDetailByCode
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }
}