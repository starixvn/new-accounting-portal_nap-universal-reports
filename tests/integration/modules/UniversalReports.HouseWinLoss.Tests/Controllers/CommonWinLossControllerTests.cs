using Fanex.Excel.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Http.Results;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Tests.Controllers
{
    public class CommonWinLossControllerTests : BaseControllerTests
    {
        public static string[] ControllerList => new[]
        {
            "SimpleGrid.SimpleGridController",
            "SimpleGrid.SimpleSiteGridController",
        };

        [TestCaseSource(nameof(ControllerList))]
        [Category("ControllersTests")]
        public void Json_Successful(string controllerName)
        {
            var queryModel = GetQueryModel(controllerName);
            var expected = TestDataLoader.LoadTestContent(controllerName, "expected");
            var controller = GetControllerWithRawWinLoss(controllerName);

            var methodInfo = controller.GetType().GetMethod("Json", new[] { queryModel.GetType() });
            var result = methodInfo.Invoke(controller, new[] { queryModel });
            var gridOptions = (result as JsonResult<GridOptions>).Content;

            ComparisonAssert.AreEqualJson(expected, gridOptions);
        }

        [TestCaseSource(nameof(ControllerList))]
        [Category("ControllersTests")]
        public void Excel_Successful(string controllerName)
        {
            var queryModel = GetQueryModel(controllerName);
            var controller = GetControllerWithRawWinLoss(controllerName);

            var methodInfo = controller.GetType().GetMethod("Excel", new[] { queryModel.GetType() });
            var result = methodInfo.Invoke(controller, new[] { queryModel });
            var workbook = (result as FanexExcelResult).Workbook;

            Assert.That(workbook.NumberOfSheets, Is.EqualTo(1));
        }

        protected Dictionary<string, object> GetQueryModel(string controllerName)
        {
            return TestDataLoader.Load<Dictionary<string, object>>(controllerName, "queryModel");
        }
    }
}