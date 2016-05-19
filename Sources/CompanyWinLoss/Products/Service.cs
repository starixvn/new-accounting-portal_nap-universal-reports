using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public interface Service
    {
        List<WinLoss> GetRMWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        ProductGroupWinLoss GetProductGroup(IEnumerable<RawWinLoss> rawWinLosses, string groupName);

        ProductWinLoss Query(WinLossCriteria criteria);
    }
}