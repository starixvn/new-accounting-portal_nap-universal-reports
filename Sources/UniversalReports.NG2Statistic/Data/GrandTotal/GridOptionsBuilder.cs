using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.GrandTotal
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(GrandTotalModel grandTotalModel, string title);
    }
}