using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface SportTypeGridOptionService
    {
        GridOptions FromWinLossModel(BasicWinLossModel winLoss, string title);
    }
}