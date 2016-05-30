using System;
using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.BalanceUpServices
{
    public interface BalanceUpSourceChooser
    {
        IEnumerable<BalanceUpSource> Determine(DateTime startDate, DateTime endDate);
    }
}