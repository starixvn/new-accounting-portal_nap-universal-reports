namespace UniversalReports.CompanyWinLoss.Soccer.GridOption
{
    using Fanex.Excel.Models;
    using UniversalReports.CompanyWinLoss.Common.Models;

    public interface BetTypesGridOptionService
    {
        GridOptions FromWinLossModel(BasicWinLossModel winLoss, string title);
    }
}
