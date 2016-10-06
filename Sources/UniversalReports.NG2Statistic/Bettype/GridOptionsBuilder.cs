using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Bettype
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(BettypeModel bettypeModel, string title);
    }
}