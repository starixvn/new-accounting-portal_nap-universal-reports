using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistics.BaseServices
{
    public interface BaseGridOptionHeaderColumn
    {
        GridOptions Build(GridOptions gridOptions, string mainColumnText, string mainColumnName, QueryModel queryModel);
    }
}