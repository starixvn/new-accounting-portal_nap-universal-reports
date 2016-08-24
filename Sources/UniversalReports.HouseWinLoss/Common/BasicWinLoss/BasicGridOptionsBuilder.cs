using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Common.BasicWinLoss
{
    public interface BasicGridOptionsBuilder
    {
        GridOptions Build(BasicWinLossModel winLoss, string title);
    }
}