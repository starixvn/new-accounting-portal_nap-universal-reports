using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface ThirdPartyProductGridOptionService
    {
        GridOptions FromProductWinLoss(ThirdPartyProductWinLossModel winLoss, string breadCrumb);
    }
}
