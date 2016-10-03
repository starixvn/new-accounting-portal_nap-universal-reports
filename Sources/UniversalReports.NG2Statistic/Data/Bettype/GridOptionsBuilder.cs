using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.Bettype
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(BettypeModel bettypeModel, string title);
    }
}