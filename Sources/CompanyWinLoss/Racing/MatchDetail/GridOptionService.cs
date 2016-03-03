using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Racing.MatchDetail
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}