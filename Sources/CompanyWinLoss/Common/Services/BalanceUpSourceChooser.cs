using System;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface BalanceUpSourceChooser
    {
        IEnumerable<BalanceUpSource> Determine(DateTime startDate, DateTime endDate);
    }
}