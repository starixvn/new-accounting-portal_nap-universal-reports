using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.BasicWinLoss
{
    public interface BasicGridOptionsBuilder
    {
        GridOptions Build(BasicWinLossModel winLoss, string title);
    }
}