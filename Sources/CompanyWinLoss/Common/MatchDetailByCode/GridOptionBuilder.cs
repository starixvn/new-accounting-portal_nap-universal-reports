using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailByCode
{
    public interface GridOptionBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }
}