using Fanex.Excel.Models;
using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.Bettype
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(BettypeModel bettypeModel, QueryModel queryModel);
    }
}