namespace UniversalReports.CompanyWinLoss.Soccer.BetType
{
    using Fanex.Excel.Models;

    public interface BetTypesGridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winLoss, string title);
    }
}
