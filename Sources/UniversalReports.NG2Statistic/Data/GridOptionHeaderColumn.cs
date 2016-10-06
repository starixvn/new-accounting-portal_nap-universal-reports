using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data
{
    public interface GridOptionHeaderColumn
    {
        GridOptions Build(GridOptions gridOptions, string mainColumnText, QueryModel queryModel);
    }
}