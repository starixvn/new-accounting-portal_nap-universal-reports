using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistics.GrandTotal
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(GrandTotalModel grandTotalModel, string title);
    }
}