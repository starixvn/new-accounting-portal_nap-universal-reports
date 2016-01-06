using NAP.Reports.CompanyWinLoss.Services.Models;
using System;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface IBalanceUpSourceChooser
    {
        IEnumerable<BalanceUpSource> Determine(DateTime startDate, DateTime endDate);
    }
}
