using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface IRawWinLossService
    {
        List<RawWinLoss> Query(WinLossCriteria criteria);

        List<RawWinLoss> QueryBySource(BalanceUpSource source, WinLossCriteria criteria);

        Task<List<RawWinLoss>> QueryBySourceAsync(BalanceUpSource source, WinLossCriteria criteria);
    }
}
