using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(ProductWinLoss winLoss, string title);
    }
}