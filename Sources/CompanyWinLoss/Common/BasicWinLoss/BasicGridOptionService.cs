using Fanex.Excel.Models;

namespace UniversalReports.CompanyWinLoss.Common.BasicWinLoss
{
    public interface BasicGridOptionService
    {
        GridOptions FromWinLossModel(BasicWinLossModel winLoss, string title);
    }
}