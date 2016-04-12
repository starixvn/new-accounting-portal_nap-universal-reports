using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;

namespace UniversalReports.CompanyWinLoss.MetricGaming.BetType
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(BasicWinLossModel winLoss, string title);
    }
}