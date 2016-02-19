using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface SportTypeGridOptionService
    {
        GridOptions FromSportTypeWinLoss(SportTypeWinLossModel winLoss, string breadCrumb);
    }
}
