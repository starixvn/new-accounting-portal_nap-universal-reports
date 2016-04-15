namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    using Fanex.Excel.Models;

    public interface GridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}
