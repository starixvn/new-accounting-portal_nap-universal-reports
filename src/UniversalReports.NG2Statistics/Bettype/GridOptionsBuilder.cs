using Fanex.Excel.Models;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Bettype
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(BettypeModel bettypeModel, QueryModel queryModel);
    }
}