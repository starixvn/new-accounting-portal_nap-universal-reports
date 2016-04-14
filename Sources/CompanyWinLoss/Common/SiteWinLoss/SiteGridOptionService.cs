using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.SiteWinLoss
{
    public interface SiteGridOptionService
    {
        GridOptions FromWinLossModel(SiteWinLossModel winLoss, string title);
    }
}