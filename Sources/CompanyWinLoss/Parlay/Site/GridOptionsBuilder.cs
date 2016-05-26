using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Parlay.Site
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(SiteParlayModel winLoss, string title);
    }
}