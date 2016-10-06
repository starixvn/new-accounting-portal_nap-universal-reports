using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.GrandTotal
{
    public interface GridOptionHeaderColumn
    {
        GridOptions Build(GridOptions gridOptions, QueryModel queryModel);
    }
}