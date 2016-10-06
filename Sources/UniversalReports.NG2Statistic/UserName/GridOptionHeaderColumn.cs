using Fanex.Excel.Models;
using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.UserName
{
    public interface GridOptionHeaderColumn
    {
        GridOptions Build(GridOptions gridOptions, QueryModel queryModel);
    }
}