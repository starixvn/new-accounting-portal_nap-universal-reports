using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.ColumnBuilders
{
    public interface MatchGridOptionColumnDecorator
    {
        GridOptions Build(GridOptions gridOptions);
    }
}
