using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public interface ISportsbookWinLossService
    {
        List<WinLoss> Query(MainReportQuery query);

        List<WinLoss> QueryBySource(BalanceUpSource source);

        Task<List<WinLoss>> QueryAsync(MainReportQuery query);

        Task<List<WinLoss>> QueryBySourceAsync(BalanceUpSource source);
    }
}
