using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail
{
    public interface RawWinLossService
    {
        List<RawWinLoss> Query(WinLossCriteria criteria);
    }
}