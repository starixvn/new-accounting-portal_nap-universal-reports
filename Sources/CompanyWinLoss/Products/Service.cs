using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public interface Service
    {
        ProductWinLoss Query(WinLossCriteria criteria);

        List<WinLoss> CalculateSportsbookDetail(IEnumerable<RawWinLoss> rawWinLosses);
    }
}