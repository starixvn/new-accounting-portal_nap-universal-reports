using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winLoss);
    }
}