using Fanex.Excel.Models;

namespace UniversalReports.CN88WinLoss.Soccer.BetTypeFull
{
    public interface GridOptionFactory
    {
        GridOptions CreateGridOption(ExcelQueryModel queryModel, string title, int isLive);
    }
}
