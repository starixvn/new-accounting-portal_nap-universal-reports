using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface BetTypeGridOptionService
    {
        GridOptions FromWinLossModel(ReportWinLossModel winLoss, string title);
    }
}