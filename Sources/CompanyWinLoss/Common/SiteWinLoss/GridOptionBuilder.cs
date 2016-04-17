using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.SiteWinLoss
{
    public interface GridOptionBuilder
    {
        GridOptions Build(SiteWinLossModel winLoss, string title);
    }
}