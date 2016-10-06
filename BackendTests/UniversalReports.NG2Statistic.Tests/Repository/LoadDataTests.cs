using Fanex.Data.Configuration;
using Fanex.Repository;
using NUnit.Framework;
using System;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.NG2Statistic.Data;
using UniversalReports.NG2Statistic.Data.Daily;

namespace UniversalReports.NG2Statistic.Tests.Repository
{
    [TestFixture]
    [Category("NG2 Loading Data")]
    public class LoadDataTests
    {
        private SimpleRepository simpleRepository;
        private BalanceUpService balance;
        private Data.Daily.Repository repository;

        [OneTimeSetUp]
        public void Init()
        {
            DbSettingProviderManager.Current.Start();
            simpleRepository = new SimpleRepositoryImp();
            balance = new BalanceUpServiceImp(simpleRepository);
            repository = new RepositoryImp(balance);
        }

        [Test]
        public void TestDailyRepository()
        {
            var queryModel = new QueryModel
            {
                BetType = "2502,2503",
                Currency = 0,
                FromDate = DateTime.Today.AddMonths(-2),
                ToDate = DateTime.Today,
                LiveStatus = -1,
                IsRealTime = true,
                MoveBetsDay = balance.Query().MoveBetsDate
            };

            var service = new DailyServiceImp(repository);
            var builder = new GridOptionsBuilderImp();
            var header = new GridOptionHeaderColumnImp();

            var dailyModel = service.Query(queryModel);
            var gridOptions = builder.Build(dailyModel, "Title");
            gridOptions = header.Build(gridOptions, "Date", queryModel);
        }
    }
}