using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.ColumnDecorators
{
    public interface MatchGridOptionColumnDecorator
    {
        GridOptions Build(GridOptions gridOptions);
    }
}
