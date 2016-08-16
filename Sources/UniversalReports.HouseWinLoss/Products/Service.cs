using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Products
{
    public interface Service
    {
        List<WinLoss> GetRMWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        ProductGroupWinLoss GetProductGroup(IEnumerable<RawWinLoss> rawWinLosses, string groupName);

        ProductWinLoss Query(WinLossCriteria criteria);
    }
}