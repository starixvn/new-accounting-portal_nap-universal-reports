namespace UniversalReports.CompanyWinLoss.Soccer.GridOption
{
    using Common.BasicWinLoss;
    using Fanex.Excel.Models;

    public interface SportTypesGridOptionService
    {
        GridOptions FromWinLossModel(BasicWinLossModel winLoss, string title);
    }
}
