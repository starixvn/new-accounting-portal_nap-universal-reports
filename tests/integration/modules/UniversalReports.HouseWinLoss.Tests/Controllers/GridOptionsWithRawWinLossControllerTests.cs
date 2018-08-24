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
                    "Bettrade.BetType.BettradeBetTypeController",
                    "Bettrade.Site.BettradeSiteController",
                    "CashOut.BetType.CashOutBetTypeController",
                    "CashOut.Site.CashOutSiteController",
                    "Casino.BetType.CasinoBetTypeController",
                    "Casino.Product.CasinoProductController",
                    "Casino.Site.CasinoSiteController",
                    "MetricGaming.BetType.MetricGamingBetTypeController",
                    "MetricGaming.Site.MetricGamingSiteController",
                    "NumberGame.MatchDetail.NumberGameMatchDetailController",
                    "OtherSports.BetType.OtherSportsBetTypeController",
                    "OtherSports.SportType.OtherSportsSportTypeController",
                    "OtherSports.NewCricket.OtherSportNewCricketController",
                    "Parlay.BetType.ParlayBetTypeController",
                    "Parlay.Site.ParlaySiteController",
                    "Products.ProductController",
                    "Racing.BetType.RacingBetTypeController",
                    "Racing.MatchDetail.RacingMatchDetailController",
                    "Racing.Site.RacingSiteController",
                    "Racing.SportType.RacingSportTypeController",
                    "Soccer.BetType.SoccerBetTypeController",
                    "Soccer.GroupBetType.SoccerGroupBetTypeController",
                    "Soccer.MajorMinor.SoccerMajorMinorController",
                    "Soccer.SumBetType.SoccerSumBetTypeController",
                    "Sportsbook.Site.SportsbookSiteController",
                    "Universal.SportType.UniversalSportTypeController",
                    "Universal.BetType.UniversalBetTypeController",
                    "Universal.Site.UniversalSiteController",
                    "VirtualSports.BetType.VirtualSportsBetTypeController",
                    "VirtualSports.RacingDetail.VirtualSportsRacingDetailController",
                    "VirtualSports.Site.VirtualSportsSiteController",
                    "VirtualSports.SportType.VirtualSportsSportTypeController",
                    "FishingWorld.BetType.FishingWorldBetTypeController",
                    "FishingWorld.Site.FishingWorldSiteController",
                    "VirtualSportsBetradar.BetType.VirtualSportsBetradarBetTypeController",
                    "VirtualSportsBetradar.Site.VirtualSportsBetradarSiteController",
                    "VirtualSportsBetradar.SportType.VirtualSportsBetradarSportTypeController",
                    "ColossusBet.BetType.ColossusBetBetTypeController",
                    "ColossusBet.Site.ColossusBetSiteController",
                    "PokerGames.BetType.PokerGamesBetTypeController",
                    "PokerGames.Site.PokerGamesSiteController",
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