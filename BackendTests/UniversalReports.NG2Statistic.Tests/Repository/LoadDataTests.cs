using System;
using Fanex.Data.Configuration;
using Fanex.Repository;
using NUnit.Framework;
using UniversalReports.Common.BalanceUpServices;
using UniversalReports.NG2Statistic.Data;
using UniversalReports.NG2Statistic.Data.Daily;

namespace UniversalReports.HouseWinLoss.Tests.Repository
{
    [TestFixture]
    [Category("NG2 Loading Data")]
    public class LoadDataTests
    {
        private SimpleRepository repository;
        private BalanceUpRange balance;

        [OneTimeSetUp]
        public void Init()
        {
            DbSettingProviderManager.Current.Start();
            repository = new SimpleRepositoryImp();
            balance = new BalanceUpServiceImp(repository).Query();
        }

        [Test]
        public void TestDailyRepository()
        {
            var criteria = new DailyCriteria()
            {
                BetType = "2502,2503,2504,2505,2506,2507,2508,2509,2510,2511,2512,2513,2514,2515,2516,2517,2518,2519,2520,2521,2522,2542,2543,2544,2545,2546,2547,2548,2549,2550,2551,2552,2582,2583,2584,2585,2586,2587,2588,2589,2590,2591,2592,2622,2623,2624,2625,2626,2627,2628,2629,2630,2631,2632,2681,2682,2683",
                Currency = 67,
                FromDate = DateTime.Today.AddMonths(-2),
                ToDate = DateTime.Today,
                LiveStatus = -1,
                IsRealTime = true,
                MoveBetsDay = balance.MoveBetsDate,
            };

            var service = new DailyServiceImp();
            var builder = new GridOptionsBuilderImp();
            var header = new GridOptionHeaderColumnImp();

            var dailyModel = service.Query(criteria);            
            var gridOptions = builder.Build(dailyModel, "Title");
            gridOptions = header.Build(gridOptions, "Date", 100);
        }
    }
}