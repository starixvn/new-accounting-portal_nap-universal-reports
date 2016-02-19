using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface SiteGridOptionService
    {
        GridOptions FromSiteWinLoss(SiteWinLoss winLoss, string site, string breadCrumb);
    }
}