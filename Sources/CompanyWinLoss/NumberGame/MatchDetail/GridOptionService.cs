using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.NumberGame.MatchDetail
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}