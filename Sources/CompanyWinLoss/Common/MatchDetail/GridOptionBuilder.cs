using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public interface GridOptionBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }
}