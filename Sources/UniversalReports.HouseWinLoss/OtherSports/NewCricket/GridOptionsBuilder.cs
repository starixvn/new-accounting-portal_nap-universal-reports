using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.OtherSports.NewCricket
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }
}