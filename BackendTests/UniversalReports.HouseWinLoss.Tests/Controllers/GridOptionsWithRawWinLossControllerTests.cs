using Fanex.Excel.Models;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web.Http.Results;

namespace UniversalReports.HouseWinLoss.Tests.Controllers
{
    public class GridOptionsWithRawWinLossControllerTests : BaseControllerTests
    {
        private static readonly string[] ControllerList = CreateTestCases();

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

        private static string[] CreateTestCases()
        {
            return new[]
            {
                "Bettrade.BetType.BettradeBetTypeController",
                "Bettrade.Site.BettradeSiteController",
                "Casino.BetType.CasinoBetTypeController",
                "Casino.Product.CasinoProductController",
                "Casino.Site.CasinoSiteController",
                "MetricGaming.BetType.MetricGamingBetTypeController",
                "MetricGaming.LiveNonLive.MetricGamingLiveNonLiveController",
                "MetricGaming.Site.MetricGamingSiteController",
                "NumberGame.MatchDetail.NumberGameMatchDetailController",
                "NumberGame.Site.NumberGameSiteController",
                "OtherSports.BetType.OtherSportsBetTypeController",
                "OtherSports.LiveNonLive.OtherSportsLiveNonLiveController",
                "OtherSports.SportType.OtherSportsSportTypeController",
                "Parlay.BetType.ParlayBetTypeController",
                "Parlay.Site.ParlaySiteController",
                "Products.ProductController",
                "Racing.BetType.RacingBetTypeController",
                "Racing.MatchDetail.RacingMatchDetailController",
                "Racing.Site.RacingSiteController",
                "Racing.SportType.RacingSportTypeController",
                "Soccer.BetType.SoccerBetTypeController",
                "Soccer.GroupBetType.SoccerGroupBetTypeController",
                "Soccer.LiveNonLive.SoccerLiveNonLiveController",
                "Soccer.MajorMinor.SoccerMajorMinorController",
                "Soccer.SumBetType.SoccerSumBetTypeController",
                "Sportsbook.Site.SportsbookSiteController",
                "Universal.SportType.UniversalSportTypeController",
                "Universal.BetType.UniversalBetTypeController",
                "Universal.BetTypeBySportType.UniversalBetTypeBySportTypeController",
                "Universal.Site.UniversalSiteController",
                "VirtualSports.BetType.VirtualSportsBetTypeController",
                "VirtualSports.RacingDetail.VirtualSportsRacingDetailController",
                "VirtualSports.Site.VirtualSportsSiteController",
                "VirtualSports.SportType.VirtualSportsSportTypeController"
            };
        }

        internal object GetQueryModel(string controllerName, [CallerFilePath] string sourceFilePath = "")
        {
            var queryModelType = GetQueryModelType(controllerName);
            var method = typeof(TestDataLoader).GetMethod("Load", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            var generic = method.MakeGenericMethod(queryModelType);
            return generic.Invoke(null, new object[] { controllerName, "queryModel", sourceFilePath });
        }

        private Type GetQueryModelType(string controllerName)
        {
            var lastPointIndex = controllerName.LastIndexOf(".");
            var queryModelName = controllerName.Substring(0, lastPointIndex) + ".QueryModel";
            var queryModelFullName = $"UniversalReports.HouseWinLoss.{queryModelName}, UniversalReports.HouseWinLoss";
            return Type.GetType(queryModelFullName);
        }
    }
}
