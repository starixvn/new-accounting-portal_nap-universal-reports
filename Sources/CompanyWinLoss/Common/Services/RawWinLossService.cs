using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface RawWinLossService
    {
        List<RawWinLoss> Query(WinLossCriteria criteria);

        List<RawWinLoss> QueryBySource(BalanceUpSource source, WinLossCriteria criteria);

        Task<List<RawWinLoss>> QueryBySourceAsync(BalanceUpSource source, WinLossCriteria criteria);
    }
}