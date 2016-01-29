using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.LiveCasino
{
    public interface ProductSummaryWinLossService
    {
        ProductSummaryWinLoss Query(WinLossCriteria criteria);
    }
}
