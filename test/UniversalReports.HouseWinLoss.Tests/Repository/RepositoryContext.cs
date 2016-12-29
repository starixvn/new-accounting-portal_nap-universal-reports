using Fanex.Data;
using Fanex.Data.OldConnectionStringProvider;
using Fanex.Data.Repository;
using System;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.HouseWinLoss.Tests.Repository
{
    public static class RepositoryContext
    {
        static RepositoryContext()
        {
            RegisterFanexData();

            var repository = new DynamicRepository();
            var balanceUpService = new BalanceUpServiceImp(repository);
            var balanceUpRange = balanceUpService.Query();
            BalanceUpDate = balanceUpRange.BalanceUpDate;
            MoveBetsDate = balanceUpRange.MoveBetsDate;
        }

        public static DateTime BalanceUpDate { get; private set; }

        public static DateTime MoveBetsDate { get; private set; }

        private static void RegisterFanexData()
        {
            DbSettingProviderManager
           .StartNewSession()
           .Use(new OldConnectionStringProvider())
           .UseDefaultDbSettingProvider(
             resourcePath: $"~/App_Data/LOCAL",
             ignoreRedundantParameters: false,
             enableWatching: true)
           .Run();
        }
    }
}