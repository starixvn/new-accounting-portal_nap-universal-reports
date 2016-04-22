using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public interface GridOptionBuilder
    {
        GridOptions Build(ProductWinLoss winLoss, string title);
    }
}