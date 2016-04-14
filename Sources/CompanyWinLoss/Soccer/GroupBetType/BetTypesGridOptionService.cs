namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    using Fanex.Excel.Models;

    public interface BetTypesGridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}
