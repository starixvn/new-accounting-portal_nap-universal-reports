using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(ProductWinLoss winLoss, string title, bool hasNode);
    }
}