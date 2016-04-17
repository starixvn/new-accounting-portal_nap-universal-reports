using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public interface RawWinLossService
    {
        List<RawWinLoss> Query(WinLossCriteria criteria);

        List<RawWinLoss> QueryBySource(BalanceUpSource source, WinLossCriteria criteria);

        Task<List<RawWinLoss>> QueryBySourceAsync(BalanceUpSource source, WinLossCriteria criteria);
    }
}