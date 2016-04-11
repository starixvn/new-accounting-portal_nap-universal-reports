using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Sportsbook.Site
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(SiteWinLossModel winLoss, string site, string title);
    }
}