using System;
using System.Web.Http.Results;
using Fanex.Excel.Models;
using NUnit.Framework;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Tests.Controllers
{
    public class GridOptionsWithMatch3rdRawWinLossControllerTests : BaseControllerTests
    {
        public static string[] ControllerList
        {
            get
            {
                return new[]
                {
                     "Bullfighting.MatchDetail.BullfightingMatchDetailController"
                };
            }
        }

        [TestCaseSource(nameof(ControllerList))]
        [Category("ControllersTests")]
        public void Json_Successful(string controllerName)
        {
            var queryModel = GetQueryModel(controllerName);
            var expected = TestDataLoader.LoadTestContent(controllerName, "expected");
            var controller = GetControllerWithMatch3rdRawWinLoss(controllerName);

            var methodInfo = controller.GetType().GetMethod("Json", new[] { queryModel.GetType() });
            var result = methodInfo.Invoke(controller, new[] { queryModel });
            var gridOptions = (result as JsonResult<GridOptions>).Content;

            ComparisonAssert.AreEqualJson(expected, gridOptions);
        }

        [TestCaseSource(nameof(ControllerList))]
        [Category("ControllersTests")]
        public void Excel_Successful(string controllerName)
        {
            var queryModel = GetExcelQueryModel(controllerName);
            var controller = GetControllerWithMatch3rdRawWinLoss(controllerName);

            var methodInfo = controller.GetType().GetMethod("Excel", new[] { queryModel.GetType() });
            var result = methodInfo.Invoke(controller, new[] { queryModel });
            var workbook = (result as FanexExcelResult).Workbook;

            Assert.That(workbook.NumberOfSheets, Is.EqualTo(1));
        }

        private object GetQueryModel(string controllerName)
        {
            switch (controllerName)
            {
                case "Bullfighting.MatchDetail.BullfightingMatchDetailController":
                    return TestDataLoader.Load<Bullfighting.MatchDetail.QueryModel>(controllerName, "queryModel");

                default:
                    throw new NotImplementedException();
            }
        }

        private object GetExcelQueryModel(string controllerName)
        {
            switch (controllerName)
            {
                case "Bullfighting.MatchDetail.BullfightingMatchDetailController":
                    return TestDataLoader.Load<Bullfighting.MatchDetail.ExcelQueryModel>(controllerName, "queryModel");

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
