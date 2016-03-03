using System;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class BalanceUpSourceChooserImp : BalanceUpSourceChooser
    {
        private readonly BalanceUpService balanceUpService;

        public BalanceUpSourceChooserImp(BalanceUpService balanceUpService)
        {
            this.balanceUpService = balanceUpService;
        }

        public IEnumerable<BalanceUpSource> Determine(DateTime startDate, DateTime endDate)
        {
            var balanceUpRange = balanceUpService.Query();

            if (startDate > balanceUpRange.MoveBetsDate)
            {
                yield return new BalanceUpSource { StartDate = startDate, EndDate = endDate, Source = "BetTrans" };
            }
            else if (startDate >= balanceUpRange.BalanceUpDate)
            {
                if (endDate > balanceUpRange.MoveBetsDate)
                {
                    yield return new BalanceUpSource { StartDate = balanceUpRange.MoveBetsDate.AddDays(1), EndDate = endDate, Source = "BetTrans" };
                }

                yield return new BalanceUpSource { StartDate = startDate, EndDate = endDate, Source = "BetTrans14" };
            }
            else
            {
                if (endDate > balanceUpRange.MoveBetsDate)
                {
                    yield return new BalanceUpSource { StartDate = balanceUpRange.MoveBetsDate.AddDays(1), EndDate = endDate, Source = "BetTrans" };
                }

                if (endDate >= balanceUpRange.BalanceUpDate)
                {
                    yield return new BalanceUpSource { StartDate = balanceUpRange.BalanceUpDate, EndDate = balanceUpRange.MoveBetsDate, Source = "BetTrans14" };
                }

                yield return new BalanceUpSource { StartDate = startDate, EndDate = balanceUpRange.BalanceUpDate.AddDays(-1), Source = "Warehouse" };
            }
        }
    }
}