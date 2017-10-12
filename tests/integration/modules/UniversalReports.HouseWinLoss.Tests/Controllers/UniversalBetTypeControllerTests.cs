using System;
using System.Collections.Generic;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Tests.Controllers;
using UniversalReports.HouseWinLoss.Universal.BetType;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Tests.Universal.BetType
{
    public class UniversalBetTypeControllerTests : BaseControllerTests
    {
        [Test]
        public void ExcelLiveNonLive_Successful()
        {
            var queryModel = new ExcelLiveNonLiveQueryModel
            {
                LiveTitle = "Any Title",
                NonLiveTitle = "Any Title"
            };
            var controller = CreateController();

            var result = controller.ExcelLiveNonLive(queryModel).Result;
            var workbook = (result as FanexExcelResult).Workbook;

            Assert.That(workbook.NumberOfSheets, Is.EqualTo(1));
        }

        private UniversalBetTypeController CreateController()
        {
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("Universal.BetType.UniversalBetTypeController", "fakeData");
            var fakeBalanceUpRange = new BalanceUpRange
            {
                BalanceUpDate = new DateTime(2016, 01, 01),
                MoveBetsDate = new DateTime(2016, 01, 01)
            };
            var repository = Substitute.For<IDynamicRepository>();
            repository.Fetch<WinLossRaw>(Arg.Any<ICriteria>())
                .Returns(fakeData);
            repository.Get<BalanceUpRange>(Arg.Any<ICriteria>())
                .Returns(fakeBalanceUpRange);

            var simpleInjector = new SimpleInjectorConfig(repository);

            var controllerType = typeof(UniversalBetTypeController);
            return simpleInjector.Container.GetInstance(controllerType) as UniversalBetTypeController;
        }
    }
}