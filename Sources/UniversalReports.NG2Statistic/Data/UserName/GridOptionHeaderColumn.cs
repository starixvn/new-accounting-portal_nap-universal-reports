using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.UserName
{
    public interface GridOptionHeaderColumn
    {
        GridOptions Build(GridOptions gridOptions, QueryModel queryModel);
    }
}