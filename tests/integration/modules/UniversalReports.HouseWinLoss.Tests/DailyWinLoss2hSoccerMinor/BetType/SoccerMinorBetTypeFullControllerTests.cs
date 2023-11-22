using System;
using System.Collections.Generic;
using System.Web.Http;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.BetType;
using UniversalReports.HouseWinLoss.Tests.Controllers;

namespace UniversalReports.HouseWinLoss.Tests.DailyWinLoss2hSoccerMinor.BetType
{
    using BalanceUpServices;
    using Results;

    public class SoccerMinorBetTypeFullControllerTests
    {
        [Category("ControllersTests")]
        [Test]
        public void Excel_Successful()
        {
            var queryModel = new ExcelQueryModel
            {
                BetTypeFullTitle = "BetTypeFullTitle",
                BetTypeLiveTitle = "BetTypeLiveTitle",
                BetTypeNonLiveTitle = "BetTypeNonLiveTitle"
            };

            var controller = CreateController();
            var methodInfo = controller.GetType().GetMethod("Excel", new[] { queryModel.GetType() });
            var result = methodInfo.Invoke(controller, new[] { queryModel });
            var workbook = (result as FanexExcelResult).Workbook;

            Assert.That(workbook.NumberOfSheets, Is.EqualTo(1));
        }

        private ApiController CreateController()
        {
            var fakeFullData = TestDataLoader.Load<List<WinLossRaw>>("Soccer.SumBetType.SoccerSumBetTypeController", "fakeData");
            var fakeLiveData = TestDataLoader.Load<List<WinLossRaw>>("Soccer.BetType.SoccerBetTypeController", "fakeData");
            var fakeNonLiveData = TestDataLoader.Load<List<WinLossRaw>>("Soccer.GroupBetType.SoccerGroupBetTypeController", "fakeData");
            var fakeBalanceUpRange = new BalanceUpRange
            {
                BalanceUpDate = new DateTime(2016, 01, 01),
                MoveBetsDate = new DateTime(2016, 01, 01)
            };
            var repository = Substitute.For<IDynamicRepository>();
            repository.Fetch<WinLossRaw>(Arg.Compat.Is<Criteria>(x => x.IsLive == 2))
                .Returns(fakeFullData);
            repository.Fetch<WinLossRaw>(Arg.Compat.Is<Criteria>(x => x.IsLive == 1))
                .Returns(fakeNonLiveData);
            repository.Fetch<WinLossRaw>(Arg.Compat.Is<Criteria>(x => x.IsLive == 0))
                .Returns(fakeLiveData);
            repository.Get<BalanceUpRange>(Arg.Compat.Any<ICriteria>())
                .Returns(fakeBalanceUpRange);

            var simpleInjector = new SimpleInjectorConfig(repository);

            var controllerFullName = "UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.BetType.SoccerMinorBetTypeFullController, UniversalReports.HouseWinLoss";
            var controllerType = Type.GetType(controllerFullName);
            return simpleInjector.Container.GetInstance(controllerType) as ApiController;
        }
    }
}