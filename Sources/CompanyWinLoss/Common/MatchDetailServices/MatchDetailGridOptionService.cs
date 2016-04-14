using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailServices
{
    public interface MatchDetailGridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}