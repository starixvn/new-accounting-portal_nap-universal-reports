using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winloss, string title);
    }
}