using Fanex.Excel.Models;

namespace UniversalReports.CN88WinLoss.Common.ColumnDecorators
{
    public interface MatchGridOptionColumnDecorator
    {
        GridOptions Build(GridOptions gridOptions);
    }
}