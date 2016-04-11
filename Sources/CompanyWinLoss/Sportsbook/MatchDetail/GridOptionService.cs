using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;

namespace UniversalReports.CompanyWinLoss.Sportsbook.MatchDetail
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}