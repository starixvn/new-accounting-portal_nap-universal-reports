using System;
using System.Collections.Generic;
using System.Web.Http;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Soccer.BetType;
using UniversalReports.HouseWinLoss.Soccer.GroupBetType;
using UniversalReports.HouseWinLoss.Soccer.SumBetType;
using UniversalReports.HouseWinLoss.Tests.Controllers;
using ExcelQueryModel = UniversalReports.HouseWinLoss.Soccer.BetTypeFull.ExcelQueryModel;

namespace UniversalReports.HouseWinLoss.Tests.Soccer.BetTypeFull
{
    using BalanceUpServices;
    using Results;

    public class SoccerBetTypeFullControllerTests
    {
        [Category("ControllersTests")]
        [Test]
        public void Excel_Successful()
        {
            var queryModel = new ExcelQueryModel
            {
                IsMajor = 1,
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
            repository.Fetch<WinLossRaw>(Arg.Compat.Any<SumBetTypeCriteria>())
                .Returns(fakeFullData);
            repository.Fetch<WinLossRaw>(Arg.Compat.Any<GroupBetTypeCriteria>())
                .Returns(fakeNonLiveData);
            repository.Fetch<WinLossRaw>(Arg.Compat.Any<BetTypeCriteria>())
                .Returns(fakeLiveData);
            repository.Get<BalanceUpRange>(Arg.Compat.Any<ICriteria>())
                .Returns(fakeBalanceUpRange);

            var simpleInjector = new SimpleInjectorConfig(repository);

            var controllerFullName = "UniversalReports.HouseWinLoss.Soccer.BetTypeFull.SoccerBetTypeFullController, UniversalReports.HouseWinLoss";
            var controllerType = Type.GetType(controllerFullName);
            return simpleInjector.Container.GetInstance(controllerType) as ApiController;
        }
    }
}