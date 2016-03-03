using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface SportTypeGridOptionService
    {
        GridOptions FromWinLossModel(SportTypeWinLossModel winLoss, string title);
    }
}