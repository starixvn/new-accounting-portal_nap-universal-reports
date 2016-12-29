using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Products
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(ProductWinLoss winLoss, string title);
    }
}