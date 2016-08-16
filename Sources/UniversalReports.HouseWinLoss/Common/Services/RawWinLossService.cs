using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Common.Services
{
    public interface RawWinLossService
    {
        List<RawWinLoss> Query(WinLossCriteria criteria);
    }
}