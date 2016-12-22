using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public interface RawWinLossService
    {
        List<RawWinLoss> Query(WinLossCriteria criteria);
    }
}