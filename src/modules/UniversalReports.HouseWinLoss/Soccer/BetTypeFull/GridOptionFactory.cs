using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Soccer.BetTypeFull
{
    public interface GridOptionFactory
    {
        GridOptions CreateGridOption(ExcelQueryModel queryModel, string title, int isLive);
    }
}
