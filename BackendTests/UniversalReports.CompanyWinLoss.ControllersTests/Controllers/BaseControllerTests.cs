using Fanex.Data.Repository;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.ControllersTests.Controllers
{
    public abstract class BaseControllerTests
    {
        internal ApiController GetControllerWithRawWinLoss(string controllerName)
        {
            var fakeData = TestDataLoader.Load<List<Common.Models.RawWinLoss>>(controllerName, "fakeData");
            var fakeBalanceUpRange = new BalanceUpRange
            {
                BalanceUpDate = new DateTime(2016, 01, 01),
                MoveBetsDate = new DateTime(2016, 01, 01)
            };
            var repository = Substitute.For<IDynamicRepository>();
            repository.Fetch<RawWinLoss>(Arg.Any<ICriteria>())
                      .Returns(fakeData);
            repository.Get<BalanceUpRange>(Arg.Any<ICriteria>())
                      .Returns(fakeBalanceUpRange);

            var simpleInjector = new SimpleInjectorConfig(repository);

            var controllerFullName = $"UniversalReports.CompanyWinLoss.{controllerName}, UniversalReports.CompanyWinLoss";
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

            var controllerFullName = $"UniversalReports.CompanyWinLoss.{controllerName}, UniversalReports.CompanyWinLoss";
            var controllerType = Type.GetType(controllerFullName);
            return simpleInjector.Container.GetInstance(controllerType) as ApiController;
        }
    }
}
