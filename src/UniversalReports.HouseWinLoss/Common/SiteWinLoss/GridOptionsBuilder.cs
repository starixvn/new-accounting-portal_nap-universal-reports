using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Common.SiteWinLoss
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(SiteWinLossModel winLoss, string title);
    }
}