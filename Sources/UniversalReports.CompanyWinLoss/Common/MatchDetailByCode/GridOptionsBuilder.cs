using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailByCode
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }
}