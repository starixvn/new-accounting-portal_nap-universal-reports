namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    using Fanex.Excel.Models;

    public interface GridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }
}
