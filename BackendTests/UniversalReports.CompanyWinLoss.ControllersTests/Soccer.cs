using Fanex.Data.Configuration;
using NUnit.Framework;
using SimpleInjector;
using System;
using UniversalReports.CompanyWinLoss.Soccer.BetType;
using UniversalReports.CompanyWinLoss.Soccer.GroupBetType;
using UniversalReports.CompanyWinLoss.Soccer.SumBetType;

namespace UniversalReports.CompanyWinLoss.ControllersTests
{
    [TestFixture]
    public class Soccer
    {
        static DateTime startDate = new DateTime(2016, 6, 5);
        static DateTime endDate = new DateTime(2016, 6, 5);
        static Container container = SimpleInjectorConfig.Container;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]

        public void SoccerBetType()
        {
            var controller = container.GetInstance<SoccerBetTypeController>();
            var model = new CompanyWinLoss.Soccer.BetType.QueryModel { IsMajor = true, IsLive = 1, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }
        [Test]
        public void SoccerGroupBetType()
        {
            var controller = container.GetInstance<SoccerGroupBetTypeController>();
            var model = new CompanyWinLoss.Soccer.BetType.QueryModel { IsMajor = true, IsLive = 0, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }
        [Test]
        public void SoccerSumBetType()
        {
            var controller = container.GetInstance<SoccerSumBetTypeController>();
            var model = new CompanyWinLoss.Soccer.BetType.QueryModel { IsMajor = true, IsLive = 2, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }
    }
}
