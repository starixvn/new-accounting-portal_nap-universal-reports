using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistics.Daily
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(DailyModel dailyModel, string title);
    }
}