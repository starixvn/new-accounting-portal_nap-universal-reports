using NAP.Reports.CompanyWinLoss.QueryModels.Main;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAP.Reports.CompanyWinLoss.Services.Main
{
    public interface IRawWinLossService
    {
        List<RawWinLoss> Query(MainQuery query);

        List<RawWinLoss> QueryBySource(BalanceUpSource source);

        Task<List<RawWinLoss>> QueryBySourceAsync(BalanceUpSource source);
    }
}
