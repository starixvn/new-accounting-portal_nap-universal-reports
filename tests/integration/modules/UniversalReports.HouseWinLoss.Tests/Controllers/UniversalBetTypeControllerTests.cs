using System;
using System.Collections.Generic;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.NG2.BetType;
using UniversalReports.HouseWinLoss.Tests.Controllers;

namespace UniversalReports.HouseWinLoss.Tests.Universal.BetType
{
    using BalanceUpServices;
    using Results;

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

        private NG2BetTypeController CreateController()
        {
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("NG2.BetType.NG2BetTypeController", "fakeData");
            var fakeBalanceUpRange = new BalanceUpRange
            {
                BalanceUpDate = new DateTime(2016, 01, 01),
                MoveBetsDate = new DateTime(2016, 01, 01)
            };
            var repository = Substitute.For<IDynamicRepository>();
            repository.Fetch<WinLossRaw>(Arg.Compat.Any<ICriteria>())
                .Returns(fakeData);
            repository.Get<BalanceUpRange>(Arg.Compat.Any<ICriteria>())
                .Returns(fakeBalanceUpRange);

            var simpleInjector = new SimpleInjectorConfig(repository);

            var controllerType = typeof(NG2BetTypeController);
            return simpleInjector.Container.GetInstance(controllerType) as NG2BetTypeController;
        }
    }
}