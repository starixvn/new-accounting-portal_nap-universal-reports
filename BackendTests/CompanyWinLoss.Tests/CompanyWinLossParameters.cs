using System;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;

namespace UniversalReports.CompanyWinLoss.Tests
{
    public class CompanyWinLossParameters
    {
        static CompanyWinLossParameters()
        {
            var balanceUpService = SimpleInjectorContainer.Instance.GetInstance<BalanceUpService>();
            var balanceUpRange = balanceUpService.Query();
            BalanceUpDate = balanceUpRange.BalanceUpDate;
            MoveBetsDate = balanceUpRange.MoveBetsDate;
        }

        public static DateTime BalanceUpDate { get; private set; }

        public static DateTime MoveBetsDate { get; private set; }
    }
}
