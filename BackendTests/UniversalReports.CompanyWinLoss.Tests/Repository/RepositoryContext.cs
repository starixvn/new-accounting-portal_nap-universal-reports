using Fanex.Data.Configuration;
using Fanex.Data.Repository;
using System;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;

namespace UniversalReports.CompanyWinLoss.DatabaseTests.Repository
{
    public class RepositoryContext
    {
        static RepositoryContext()
        {
            DbSettingProviderManager.Current.Start();

            var repository = new DynamicRepository();
            var balanceUpService = new BalanceUpServiceImp(repository);
            var balanceUpRange = balanceUpService.Query();
            BalanceUpDate = balanceUpRange.BalanceUpDate;
            MoveBetsDate = balanceUpRange.MoveBetsDate;
        }

        public static DateTime BalanceUpDate { get; private set; }

        public static DateTime MoveBetsDate { get; private set; }
    }
}
