using Fanex.Excel.Models;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.MetricGaming.LiveNonLive
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(BasicWinLossModel winLoss, string title);
    }
}