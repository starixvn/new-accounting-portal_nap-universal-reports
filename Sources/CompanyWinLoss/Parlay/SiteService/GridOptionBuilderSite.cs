using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Parlay.SiteService
{
    public interface GridOptionBuilderSite
    {
        GridOptions Build(SiteParlayModel winLoss, string title);
    }
}