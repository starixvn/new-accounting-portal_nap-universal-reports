using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Common.ColumnDecorators
{
    public interface GridOptionColumnDecorator
    {
        GridOptions Build(GridOptions gridOptions, string mainColumnText, int mainColumnWidth = 180);
    }
}