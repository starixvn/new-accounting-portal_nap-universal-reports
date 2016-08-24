using Fanex.Excel.Models;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http.Results;

namespace UniversalReports.CompanyWinLoss.Tests.Controllers
{
    public class GridOptionsWithRawWinLossControllerTests : BaseControllerTests
    {
        private static string[] controllerList = CreateTestCases();

        [TestCaseSource("controllerList")]
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
                "Universal.BetType.UniversalBetTypeController",
                "Universal.Site.UniversalSiteController",
                "VirtualSports.BetType.VirtualSportsBetTypeController",
                "VirtualSports.RacingDetail.VirtualSportsRacingDetailController",
                "VirtualSports.Site.VirtualSportsSiteController",
                "VirtualSports.SportType.VirtualSportsSportTypeController"
            };
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed. Suppression is OK here.")]
        internal object GetQueryModel(string controllerName)
        {
            switch (controllerName)
            {
                case "Bettrade.BetType.BettradeBetTypeController":
                    return TestDataLoader.Load<Bettrade.BetType.QueryModel>(controllerName, "queryModel");
                case "Casino.BetType.CasinoBetTypeController":
                    return TestDataLoader.Load<Casino.BetType.QueryModel>(controllerName, "queryModel");
                case "Casino.Product.CasinoProductController":
                    return TestDataLoader.Load<Casino.Product.QueryModel>(controllerName, "queryModel");
                case "Casino.Site.CasinoSiteController":
                    return TestDataLoader.Load<Casino.Site.QueryModel>(controllerName, "queryModel");
                case "MetricGaming.BetType.MetricGamingBetTypeController":
                    return TestDataLoader.Load<MetricGaming.BetType.QueryModel>(controllerName, "queryModel");
                case "MetricGaming.LiveNonLive.MetricGamingLiveNonLiveController":
                    return TestDataLoader.Load<MetricGaming.LiveNonLive.QueryModel>(controllerName, "queryModel");
                case "MetricGaming.Site.MetricGamingSiteController":
                    return TestDataLoader.Load<MetricGaming.Site.QueryModel>(controllerName, "queryModel");
                case "NumberGame.BetType.NumberGameBetTypeController":
                    return TestDataLoader.Load<NumberGame.BetType.QueryModel>(controllerName, "queryModel");
                case "NumberGame.MatchDetail.NumberGameMatchDetailController":
                    return TestDataLoader.Load<NumberGame.MatchDetail.QueryModel>(controllerName, "queryModel");
                case "NumberGame.Site.NumberGameSiteController":
                    return TestDataLoader.Load<NumberGame.Site.QueryModel>(controllerName, "queryModel");
                case "OtherSports.BetType.OtherSportsBetTypeController":
                    return TestDataLoader.Load<OtherSports.BetType.QueryModel>(controllerName, "queryModel");
                case "OtherSports.LiveNonLive.OtherSportsLiveNonLiveController":
                    return TestDataLoader.Load<OtherSports.LiveNonLive.QueryModel>(controllerName, "queryModel");
                case "OtherSports.SportType.OtherSportsSportTypeController":
                    return TestDataLoader.Load<OtherSports.SportType.QueryModel>(controllerName, "queryModel");
                case "Parlay.BetType.ParlayBetTypeController":
                    return TestDataLoader.Load<Parlay.BetType.QueryModel>(controllerName, "queryModel");
                case "Parlay.Site.ParlaySiteController":
                    return TestDataLoader.Load<Parlay.Site.QueryModel>(controllerName, "queryModel");
                case "Products.ProductController":
                    return TestDataLoader.Load<Products.QueryModel>(controllerName, "queryModel");
                case "Racing.BetType.RacingBetTypeController":
                    return TestDataLoader.Load<Racing.BetType.QueryModel>(controllerName, "queryModel");
                case "Racing.MatchDetail.RacingMatchDetailController":
                    return TestDataLoader.Load<Racing.MatchDetail.QueryModel>(controllerName, "queryModel");
                case "Racing.Site.RacingSiteController":
                    return TestDataLoader.Load<Racing.Site.QueryModel>(controllerName, "queryModel");
                case "Racing.SportType.RacingSportTypeController":
                    return TestDataLoader.Load<Racing.SportType.QueryModel>(controllerName, "queryModel");
                case "Soccer.BetType.SoccerBetTypeController":
                    return TestDataLoader.Load<Soccer.BetType.QueryModel>(controllerName, "queryModel");
                case "Soccer.GroupBetType.SoccerGroupBetTypeController":
                    return TestDataLoader.Load<Soccer.GroupBetType.QueryModel>(controllerName, "queryModel");
                case "Soccer.LiveNonLive.SoccerLiveNonLiveController":
                    return TestDataLoader.Load<Soccer.LiveNonLive.QueryModel>(controllerName, "queryModel");
                case "Soccer.MajorMinor.SoccerMajorMinorController":
                    return TestDataLoader.Load<Soccer.MajorMinor.QueryModel>(controllerName, "queryModel");
                case "Soccer.SumBetType.SoccerSumBetTypeController":
                    return TestDataLoader.Load<Soccer.SumBetType.QueryModel>(controllerName, "queryModel");
                case "Sportsbook.Site.SportsbookSiteController":
                    return TestDataLoader.Load<Sportsbook.Site.QueryModel>(controllerName, "queryModel");
                case "Universal.BetType.UniversalBetTypeController":
                    return TestDataLoader.Load<Universal.BetType.QueryModel>(controllerName, "queryModel");
                case "Universal.Site.UniversalSiteController":
                    return TestDataLoader.Load<Universal.Site.QueryModel>(controllerName, "queryModel");
                case "VirtualSports.BetType.VirtualSportsBetTypeController":
                    return TestDataLoader.Load<VirtualSports.BetType.QueryModel>(controllerName, "queryModel");
                case "VirtualSports.RacingDetail.VirtualSportsRacingDetailController":
                    return TestDataLoader.Load<VirtualSports.RacingDetail.QueryModel>(controllerName, "queryModel");
                case "VirtualSports.Site.VirtualSportsSiteController":
                    return TestDataLoader.Load<VirtualSports.Site.QueryModel>(controllerName, "queryModel");
                case "VirtualSports.SportType.VirtualSportsSportTypeController":
                    return TestDataLoader.Load<VirtualSports.SportType.QueryModel>(controllerName, "queryModel");
                default:
                    return null;
            }
        }
    }
}
