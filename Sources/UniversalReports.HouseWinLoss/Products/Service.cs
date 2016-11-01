using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Products
{
    public interface Service
    {
        List<WinLoss> GetRMWinLoss(IEnumerable<WinLossRaw> rawWinLosses);

        ProductGroupWinLoss GetProductGroup(IEnumerable<WinLossRaw> rawWinLosses, string groupName);

        ProductWinLoss Query(WinLossCriteria criteria);
    }
}