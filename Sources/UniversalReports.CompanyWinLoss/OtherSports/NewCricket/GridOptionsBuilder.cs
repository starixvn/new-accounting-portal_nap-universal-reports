using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.OtherSports.NewCricket
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }
}
