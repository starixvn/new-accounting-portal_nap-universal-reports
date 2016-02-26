using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winloss);
    }
}
