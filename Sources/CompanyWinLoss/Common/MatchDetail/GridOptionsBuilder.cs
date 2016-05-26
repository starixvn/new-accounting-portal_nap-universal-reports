using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }
}