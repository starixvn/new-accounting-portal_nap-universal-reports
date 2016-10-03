using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(DailyModel dailyModel, string title);
    }
}