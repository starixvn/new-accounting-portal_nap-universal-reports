using Fanex.Data.Repository;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Tests.Controllers
{
    public abstract class BaseControllerTests
    {
        internal ApiController GetControllerWithRawWinLoss(string controllerName)
        {
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>(controllerName, "fakeData");
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

            var controllerFullName = $"UniversalReports.HouseWinLoss.{controllerName}, UniversalReports.HouseWinLoss";
            var controllerType = Type.GetType(controllerFullName);
            return simpleInjector.Container.GetInstance(controllerType) as ApiController;
        }

        internal ApiController GetControllerWithMatchRawWinLoss(string controllerName)
        {
            var fakeData = TestDataLoader.Load<List<Common.MatchDetail.RawWinLoss>>(controllerName, "fakeData");
            var fakeBalanceUpRange = new BalanceUpRange
            {
                BalanceUpDate = new DateTime(2016, 01, 01),
                MoveBetsDate = new DateTime(2016, 01, 01)
            };
            var repository = Substitute.For<IDynamicRepository>();
            repository.Fetch<Common.MatchDetail.RawWinLoss>(Arg.Any<ICriteria>())
                .Returns(fakeData);
            repository.Get<BalanceUpRange>(Arg.Any<ICriteria>())
                .Returns(fakeBalanceUpRange);

            var simpleInjector = new SimpleInjectorConfig(repository);

            var controllerFullName = $"UniversalReports.HouseWinLoss.{controllerName}, UniversalReports.HouseWinLoss";
            var controllerType = Type.GetType(controllerFullName);
            return simpleInjector.Container.GetInstance(controllerType) as ApiController;
        }
    }
}