using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.ColumnDecorators
{
    public interface GridOptionColumnDecorator
    {
        GridOptions Build(GridOptions gridOptions, string mainColumnText, int mainColumnWidth = 200);
    }
}