using Fanex.Excel.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace UniversalReports.HouseWinLoss.Tests.Controllers
{
    public class TwoGridOptionsWithRawWinLossControllerTests : GridOptionsWithRawWinLossControllerTests
    {
        public static string[] TwoGridOptionsControllerList => new[]
        {
            "Soccer.LiveNonLive.SoccerLiveNonLiveController",
            "OtherSports.LiveNonLive.OtherSportsLiveNonLiveController",
            "MetricGaming.LiveNonLive.MetricGamingLiveNonLiveController",
            "CashOut.LiveNonLive.CashOutLiveNonLiveController"
        };

        [TestCaseSource(nameof(TwoGridOptionsControllerList))]
        [Category("ControllersTests")]
        public void Test_Json_Successful(string controllerName)
        {
            var queryModel = GetQueryModel(controllerName);
            var expected = TestDataLoader.LoadTestContent(controllerName, "expected");
            var controller = GetControllerWithRawWinLoss(controllerName);

            var methodInfo = controller.GetType().GetMethod("Json", new[] { queryModel.GetType() });
            var result = methodInfo.Invoke(controller, new[] { queryModel });
            var gridOptions = (result as JsonResult<IEnumerable<GridOptions>>).Content;

            ComparisonAssert.AreEqualJson(expected, gridOptions);
        }

        [TestCaseSource(nameof(TwoGridOptionsControllerList))]
        [Category("ControllersTests")]
        public void Test_Excel_Successful(string controllerName)
        {
            Excel_Successful(controllerName);
        }
    }
}