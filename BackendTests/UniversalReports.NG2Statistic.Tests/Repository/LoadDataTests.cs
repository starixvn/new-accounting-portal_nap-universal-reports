using System;
using Fanex.Data.Configuration;
using Fanex.Repository;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.NG2Statistic.Common;
using UniversalReports.NG2Statistic.Daily;

namespace UniversalReports.NG2Statistic.Tests.Repository
{
    [TestFixture]
    [Category("NG2 Loading Data")]
    public class LoadDataTests
    {
        private SimpleRepository simpleRepository;
        private BalanceUpService balance;

        [OneTimeSetUp]
        public void Init()
        {
            DbSettingProviderManager.Current.Start();
            simpleRepository = new SimpleRepositoryImp();
            balance = new BalanceUpServiceImp(simpleRepository);
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

            var service = new DailyServiceImp(balance);
            service.DataRaw(queryModel);
        }
    }
}