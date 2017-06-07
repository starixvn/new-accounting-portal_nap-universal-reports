using Fanex.Excel.Models;
using NUnit.Framework;
using System;
using System.Web.Http.Results;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Tests.Controllers
{
    public class GridOptionsWithMatchRawWinLossControllerTests : BaseControllerTests
    {
        public static string[] ControllerList
        {
            get
            {
                return new[]
                {
                     "MetricGaming.MatchDetail.MetricGamingMatchDetailController",
                     "Sportsbook.MatchDetail.SportsbookMatchDetailController",
                     "Sportsbook.OutrightMatchDetail.SportsbookOutrightMatchDetailController",
                     "VirtualSports.SportsbookDetail.VirtualSportsSportsbookDetailController"
                };
            }
        }

        [TestCaseSource(nameof(ControllerList))]
        [Category("ControllersTests")]
        public void Json_Successful(string controllerName)
        {
            var queryModel = GetQueryModel(controllerName);
            var expected = TestDataLoader.LoadTestContent(controllerName, "expected");
            var controller = GetControllerWithMatchRawWinLoss(controllerName);

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
            var controller = GetControllerWithMatchRawWinLoss(controllerName);

            var methodInfo = controller.GetType().GetMethod("Excel", new[] { queryModel.GetType() });
            var result = methodInfo.Invoke(controller, new[] { queryModel });
            var workbook = (result as FanexExcelResult).Workbook;

            Assert.That(workbook.NumberOfSheets, Is.EqualTo(1));
        }

        private object GetQueryModel(string controllerName)
        {
            switch (controllerName)
            {
                case "MetricGaming.MatchDetail.MetricGamingMatchDetailController":
                    return TestDataLoader.Load<MetricGaming.MatchDetail.QueryModel>(controllerName, "queryModel");

                case "Sportsbook.MatchDetail.SportsbookMatchDetailController":
                    return TestDataLoader.Load<Sportsbook.MatchDetail.QueryModel>(controllerName, "queryModel");

                case "Sportsbook.OutrightMatchDetail.SportsbookOutrightMatchDetailController":
                    return TestDataLoader.Load<Sportsbook.OutrightMatchDetail.QueryModel>(controllerName, "queryModel");

                case "VirtualSports.SportsbookDetail.VirtualSportsSportsbookDetailController":
                    return TestDataLoader.Load<VirtualSports.SportsbookDetail.QueryModel>(controllerName, "queryModel");

                default:
                    throw new NotImplementedException();
            }
        }

        private object GetExcelQueryModel(string controllerName)
        {
            switch (controllerName)
            {
                case "MetricGaming.MatchDetail.MetricGamingMatchDetailController":
                    return TestDataLoader.Load<MetricGaming.MatchDetail.ExcelQueryModel>(controllerName, "queryModel");

                case "Sportsbook.MatchDetail.SportsbookMatchDetailController":
                    return TestDataLoader.Load<Sportsbook.MatchDetail.ExcelQueryModel>(controllerName, "queryModel");

                case "Sportsbook.OutrightMatchDetail.SportsbookOutrightMatchDetailController":
                    return TestDataLoader.Load<Sportsbook.OutrightMatchDetail.ExcelQueryModel>(controllerName, "queryModel");

                case "VirtualSports.SportsbookDetail.VirtualSportsSportsbookDetailController":
                    return TestDataLoader.Load<VirtualSports.SportsbookDetail.ExcelQueryModel>(controllerName, "queryModel");

                default:
                    throw new NotImplementedException();
            }
        }
    }
}