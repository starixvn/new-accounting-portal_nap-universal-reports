using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.MatchDetail
{
    public interface SoccerMinorMatchGridOptionColumnDecorator
    {
        GridOptions Build(GridOptions gridOptions, string sortColumnName, string sortDirection);
    }
}