using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.BasicWinLoss
{
    public interface BasicGridOptionBuilder
    {
        GridOptions Build(BasicWinLossModel winLoss, string title);
    }
}