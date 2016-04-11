namespace UniversalReports.CompanyWinLoss.Soccer.GridOption
{
    using UniversalReports.CompanyWinLoss.Common.Models;
    using Fanex.Excel.Models;

    public interface SportTypesGridOptionService
    {
        GridOptions FromWinLossModel(BasicWinLossModel winLoss, string title);
    }
}
