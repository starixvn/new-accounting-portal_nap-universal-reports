using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailServices
{
    public interface MatchDetailRawWinLossService
    {
        List<MatchDetailRawWinLoss> Query(WinLossCriteria criteria);

        List<MatchDetailRawWinLoss> QueryBySource(BalanceUpSource source, WinLossCriteria criteria);

        Task<List<MatchDetailRawWinLoss>> QueryBySourceAsync(BalanceUpSource source, WinLossCriteria criteria);
    }
}