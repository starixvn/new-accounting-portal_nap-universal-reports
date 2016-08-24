using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.SiteWinLoss
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(SiteWinLossModel winLoss, string title);
    }
}