using NAP.Reports.CompanyWinLoss.Services.Models;
using System;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class BalanceUpSourceChooserImp : BalanceUpSourceChooser
    {
        private BalanceUpService _balanceUpService;

        public BalanceUpSourceChooserImp(BalanceUpService balanceUpService)
        {
            _balanceUpService = balanceUpService;
        }

        public IEnumerable<BalanceUpSource> Determine(DateTime startDate, DateTime endDate)
        {
            var _balanceUpRange = _balanceUpService.Query();

            if (startDate > _balanceUpRange.MoveBetsDate)
            {
                yield return new BalanceUpSource { StartDate = startDate, EndDate = endDate, Source = "BetTrans" };
            }
            else if (startDate >= _balanceUpRange.BalanceUpDate)
            {
                if (endDate > _balanceUpRange.MoveBetsDate)
                {
                    yield return new BalanceUpSource { StartDate = _balanceUpRange.MoveBetsDate.AddDays(1), EndDate = endDate, Source = "BetTrans" };
                }

                yield return new BalanceUpSource { StartDate = startDate, EndDate = _balanceUpRange.MoveBetsDate, Source = "BetTrans14" };
            }
            else
            {
                if (endDate > _balanceUpRange.MoveBetsDate)
                {
                    yield return new BalanceUpSource { StartDate = _balanceUpRange.MoveBetsDate.AddDays(1), EndDate = endDate, Source = "BetTrans" };
                }

                if (endDate >= _balanceUpRange.BalanceUpDate)
                {
                    yield return new BalanceUpSource { StartDate = _balanceUpRange.BalanceUpDate, EndDate = _balanceUpRange.MoveBetsDate, Source = "BetTrans14" };
                }

                yield return new BalanceUpSource { StartDate = startDate, EndDate = _balanceUpRange.BalanceUpDate.AddDays(-1), Source = "Warehouse" };
            }
        }
    }
}
