namespace UniversalReports.CompanyWinLoss.Soccer.MajorOrMinorBetTypes
{
    using Common.BasicWinLoss;
    using Fanex.Excel.Models;

    public interface BetTypesGridOptionService
    {
        GridOptions FromWinLossModel(BasicWinLossModel winLoss, string title);
    }
}
