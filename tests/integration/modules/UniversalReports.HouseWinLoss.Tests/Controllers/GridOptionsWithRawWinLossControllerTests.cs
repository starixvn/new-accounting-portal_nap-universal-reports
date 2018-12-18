using System;
using System.Reflection;
using System.Web.Http.Results;
using Fanex.Excel.Models;
using NUnit.Framework;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Tests.Controllers
{
    public class GridOptionsWithRawWinLossControllerTests : BaseControllerTests
    {
        public static string[] ControllerList
        {
            get
            {
                return new[]
                {
                    "NumberGame.MatchDetail.NumberGameMatchDetailController",
                    "OtherSports.NewCricket.OtherSportNewCricketController",
                    "Parlay.Site.ParlaySiteController",
                    "Products.ProductController",
                    "Racing.MatchDetail.RacingMatchDetailController",
                    "Soccer.GroupBetType.SoccerGroupBetTypeController",
                    "Soccer.SumBetType.SoccerSumBetTypeController",
                    "VirtualSports.RacingDetail.VirtualSportsRacingDetailController"
                };
            }
        }

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
            var queryModel = GetExcelQueryModel(controllerName);
            var controller = GetControllerWithRawWinLoss(controllerName);

            var methodInfo = controller.GetType().GetMethod("Excel", new[] { queryModel.GetType() });
            var result = methodInfo.Invoke(controller, new[] { queryModel });
            var workbook = (result as FanexExcelResult).Workbook;

            Assert.That(workbook.NumberOfSheets, Is.EqualTo(1));
        }

        protected object GetQueryModel(string controllerName)
        {
            var queryModelType = GetQueryModelType(controllerName);
            var method = typeof(TestDataLoader).GetMethod("Load", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            var generic = method.MakeGenericMethod(queryModelType);
            return generic.Invoke(null, new object[] { controllerName, "queryModel" });
        }

        protected Type GetQueryModelType(string controllerName)
        {
            var lastPointIndex = controllerName.LastIndexOf(".", StringComparison.CurrentCultureIgnoreCase);
            var queryModelName = controllerName.Substring(0, lastPointIndex) + ".QueryModel";
            var queryModelFullName = $"UniversalReports.HouseWinLoss.{queryModelName}, UniversalReports.HouseWinLoss";
            return Type.GetType(queryModelFullName);
        }

        protected object GetExcelQueryModel(string controllerName)
        {
            var queryModelType = GetExcelQueryModelType(controllerName);
            var method = typeof(TestDataLoader).GetMethod("Load", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            var generic = method.MakeGenericMethod(queryModelType);
            return generic.Invoke(null, new object[] { controllerName, "queryModel" });
        }

        protected Type GetExcelQueryModelType(string controllerName)
        {
            var lastPointIndex = controllerName.LastIndexOf(".", StringComparison.CurrentCultureIgnoreCase);
            var queryModelName = controllerName.Substring(0, lastPointIndex) + ".ExcelQueryModel";
            var queryModelFullName = $"UniversalReports.HouseWinLoss.{queryModelName}, UniversalReports.HouseWinLoss";
            return Type.GetType(queryModelFullName);
        }
    }
}