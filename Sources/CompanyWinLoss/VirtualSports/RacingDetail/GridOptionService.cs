using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winLoss);
    }
}