using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Parlay.Site
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(SiteParlayModel winLoss, string title);
    }
}