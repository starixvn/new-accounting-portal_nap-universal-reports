using Fanex.Excel.Models;
using NUnit.Framework;
using System.Web.Http.Results;

namespace UniversalReports.HouseWinLoss.Tests.Controllers
{
    public class GridOptionsWithMatchRawWinLossControllerTests : BaseControllerTests
    {
        private static readonly string[] ControllerList = CreateTestCases();

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

        private static string[] CreateTestCases()
        {
            return new[]
            {
                 "MetricGaming.MatchDetail.MetricGamingMatchDetailController",
                 "Sportsbook.MatchDetail.SportsbookMatchDetailController",
                 "Sportsbook.OutrightMatchDetail.SportsbookOutrightMatchDetailController",
                 "VirtualSports.SportsbookDetail.VirtualSportsSportsbookDetailController"
            };
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

                default: return null;
            }
        }
    }
}