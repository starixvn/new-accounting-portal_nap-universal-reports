using System;
using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.BalanceUpServices
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
                return DetermineWhenStartDateMoreThanMoveBetsDate(startDate, endDate);
            }
            else if (startDate >= balanceUpRange.BalanceUpDate)
            {
                return DetermineWhenStartDateMoreThanBalanceUpDate(startDate, endDate, balanceUpRange);
            }
            else
            {
                return DetermineWhenStartDateLessThanBalanceUpDate(startDate, endDate, balanceUpRange);
            }
        }

        private IEnumerable<BalanceUpSource> DetermineWhenStartDateMoreThanMoveBetsDate(DateTime startDate, DateTime endDate)
        {
            yield return new BalanceUpSource
            {
                StartDate = startDate,
                EndDate = endDate,
                Source = "BetTrans"
            };
        }

        private IEnumerable<BalanceUpSource> DetermineWhenStartDateMoreThanBalanceUpDate(DateTime startDate, DateTime endDate, BalanceUpRange balanceUpRange)
        {
            if (endDate > balanceUpRange.MoveBetsDate)
            {
                yield return new BalanceUpSource
                {
                    StartDate = balanceUpRange.MoveBetsDate.AddDays(1),
                    EndDate = endDate,
                    Source = "BetTrans"
                };
            }

            yield return new BalanceUpSource
            {
                StartDate = startDate,
                EndDate = new DateTime(Math.Min(balanceUpRange.MoveBetsDate.Ticks, endDate.Ticks)),
                Source = "BetTrans14"
            };
        }

        private IEnumerable<BalanceUpSource> DetermineWhenStartDateLessThanBalanceUpDate(DateTime startDate, DateTime endDate, BalanceUpRange balanceUpRange)
        {
            if (endDate > balanceUpRange.MoveBetsDate)
            {
                yield return new BalanceUpSource
                {
                    StartDate = balanceUpRange.MoveBetsDate.AddDays(1),
                    EndDate = endDate,
                    Source = "BetTrans"
                };
            }

            if (endDate >= balanceUpRange.BalanceUpDate)
            {
                yield return new BalanceUpSource
                {
                    StartDate = balanceUpRange.BalanceUpDate,
                    EndDate = new DateTime(Math.Min(balanceUpRange.MoveBetsDate.Ticks, endDate.Ticks)),
                    Source = "BetTrans14"
                };
            }

            yield return new BalanceUpSource
            {
                StartDate = startDate,
                EndDate = new DateTime(Math.Min(balanceUpRange.BalanceUpDate.AddDays(-1).Ticks, endDate.Ticks)),
                Source = "Warehouse"
            };
        }
    }
}