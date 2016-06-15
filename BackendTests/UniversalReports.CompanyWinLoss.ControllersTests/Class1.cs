using Fanex.Data.Configuration;
using NUnit.Framework;
using SimpleInjector;
using System;
using UniversalReports.CompanyWinLoss.Bettrade.BetType;
using UniversalReports.CompanyWinLoss.Casino.BetType;
using UniversalReports.CompanyWinLoss.Casino.Product;
using UniversalReports.CompanyWinLoss.Casino.Site;
using UniversalReports.CompanyWinLoss.MetricGaming.BetType;
using UniversalReports.CompanyWinLoss.MetricGaming.LiveNonLive;
using UniversalReports.CompanyWinLoss.MetricGaming.MatchDetail;
using UniversalReports.CompanyWinLoss.MetricGaming.Site;
using UniversalReports.CompanyWinLoss.NumberGame.BetType;
using UniversalReports.CompanyWinLoss.NumberGame.MatchDetail;
using UniversalReports.CompanyWinLoss.NumberGame.Site;
using UniversalReports.CompanyWinLoss.OtherSports.BetType;
using UniversalReports.CompanyWinLoss.OtherSports.LiveNonLive;
using UniversalReports.CompanyWinLoss.OtherSports.SportType;
using UniversalReports.CompanyWinLoss.Parlay.BetType;
using UniversalReports.CompanyWinLoss.Parlay.Site;
using UniversalReports.CompanyWinLoss.Products;
using UniversalReports.CompanyWinLoss.Racing.BetType;
using UniversalReports.CompanyWinLoss.Racing.MatchDetail;
using UniversalReports.CompanyWinLoss.Racing.Site;
using UniversalReports.CompanyWinLoss.Racing.SportType;
using UniversalReports.CompanyWinLoss.Soccer.LiveNonLive;
using UniversalReports.CompanyWinLoss.Soccer.MajorMinor;
using UniversalReports.CompanyWinLoss.Sportsbook.MatchDetail;
using UniversalReports.CompanyWinLoss.Sportsbook.OutrightMatchDetail;
using UniversalReports.CompanyWinLoss.Sportsbook.Site;
using UniversalReports.CompanyWinLoss.Universal.BetType;
using UniversalReports.CompanyWinLoss.Universal.Site;
using UniversalReports.CompanyWinLoss.VirtualSports.BetType;
using UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail;
using UniversalReports.CompanyWinLoss.VirtualSports.Site;
using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail;
using UniversalReports.CompanyWinLoss.VirtualSports.SportType;

namespace UniversalReports.CompanyWinLoss.ControllersTests
{
    [TestFixture]
    public class Class1
    {
        static DateTime startDate = new DateTime(2016, 6, 5);
        static DateTime endDate = new DateTime(2016, 6, 5);
        static Container container = SimpleInjectorConfig.Container;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        public void Bettrade()
        {
            var controller = container.GetInstance<BettradeBetTypeController>();
            var model = new CompanyWinLoss.Bettrade.BetType.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }
        [Test]
        public void CasinoBetType()
        {
            var controller = container.GetInstance<CasinoBetTypeController>();
            var model = new CompanyWinLoss.Casino.BetType.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true, ProductId = 6 };
            controller.Json(model);
        }
        [Test]
        public void CasinoProduct()
        {
            var controller = container.GetInstance<CasinoProductController>();
            var model = new CompanyWinLoss.Casino.Product.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true, CasinoType = 1 };
            controller.Json(model);
        }

        [Test]
        public void CasinoSite()
        {
            var controller = container.GetInstance<CasinoSiteController>();
            var model = new CompanyWinLoss.Casino.Site.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true, Site = "Credit", BetType = 2101 };
            controller.Json(model);
        }

        [Test]
        public void MetricGamingBetType()
        {
            var controller = container.GetInstance<MetricGamingBetTypeController>();
            var model = new CompanyWinLoss.MetricGaming.BetType.QueryModel { IsLive = 2, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }


        [Test]
        public void MetricGamingLiveNonLive()
        {
            var controller = container.GetInstance<MetricGamingLiveNonLiveController>();
            var model = new CompanyWinLoss.MetricGaming.LiveNonLive.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void MetricGamingMatchDetail()
        {
            var controller = container.GetInstance<MetricGamingMatchDetailController>();
            var model = new CompanyWinLoss.MetricGaming.MatchDetail.QueryModel { IsLive = 2, BetType = 1, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void MetricGamingSite()
        {
            var controller = container.GetInstance<MetricGamingSiteController>();
            var model = new CompanyWinLoss.MetricGaming.Site.QueryModel { IsLive = 2, BetType = 1, Site = "Credit", StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void NumberGameBetType()
        {
            var controller = container.GetInstance<NumberGameBetTypeController>();
            var model = new CompanyWinLoss.NumberGame.BetType.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }



        [Test]
        public void NumberGameMatchDetail()
        {
            var controller = container.GetInstance<NumberGameMatchDetailController>();
            var model = new CompanyWinLoss.NumberGame.MatchDetail.QueryModel { IsLive = false, BetType = 81, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void NumberGameSite()
        {
            var controller = container.GetInstance<NumberGameSiteController>();
            var model = new CompanyWinLoss.NumberGame.Site.QueryModel { IsLive = false, BetType = 81, Site = "Credit", StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }


        [Test]
        public void OtherSportsBetType()
        {
            var controller = container.GetInstance<OtherSportsBetTypeController>();
            var model = new CompanyWinLoss.OtherSports.BetType.QueryModel { SportType = 2, IsLive = 2, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }
        [Test]
        public void OtherSportsSportType()
        {
            var controller = container.GetInstance<OtherSportsSportTypeController>();
            var model = new CompanyWinLoss.OtherSports.SportType.QueryModel { IsLive = 2, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void OtherSportsLiveNonLive()
        {
            var controller = container.GetInstance<OtherSportsLiveNonLiveController>();
            var model = new CompanyWinLoss.OtherSports.LiveNonLive.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }


        [Test]
        public void ParlayBetType()
        {
            var controller = container.GetInstance<ParlayBetTypeController>();
            var model = new CompanyWinLoss.Parlay.BetType.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void ParlaySite()
        {
            var controller = container.GetInstance<ParlaySiteController>();
            var model = new CompanyWinLoss.Parlay.Site.QueryModel { Site = "Credit", StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void Products()
        {
            var controller = container.GetInstance<ProductController>();
            var model = new CompanyWinLoss.Products.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void RacingBetType()
        {
            var controller = container.GetInstance<RacingBetTypeController>();
            var model = new CompanyWinLoss.Racing.BetType.QueryModel { SportType = 151, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }
        [Test]
        public void RacingSportType()
        {
            var controller = container.GetInstance<RacingSportTypeController>();
            var model = new CompanyWinLoss.Racing.SportType.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }



        [Test]
        public void RacingMatchDetail()
        {
            var controller = container.GetInstance<RacingMatchDetailController>();
            var model = new CompanyWinLoss.Racing.MatchDetail.QueryModel { SportType = 151, BetType = 31, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void RacingSite()
        {
            var controller = container.GetInstance<RacingSiteController>();
            var model = new CompanyWinLoss.Racing.Site.QueryModel { SportType = 151, BetType = 31, Site = "Credit", StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }


        [Test]
        public void SoccerMajorMinor()
        {
            var controller = container.GetInstance<SoccerMajorMinorController>();
            var model = new CompanyWinLoss.Soccer.MajorMinor.QueryModel { IsLive = 2, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void SoccerLiveNonLive()
        {
            var controller = container.GetInstance<SoccerLiveNonLiveController>();
            var model = new CompanyWinLoss.Soccer.LiveNonLive.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void SportsbookMatchDetail()
        {
            var controller = container.GetInstance<SportsbookMatchDetailController>();
            var model = new CompanyWinLoss.Sportsbook.MatchDetail.QueryModel { BetType = 1, IsHedge = false, SportType = 1, IsLive = 2, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void SportsbookOutrightMatchDetail()
        {
            var controller = container.GetInstance<SportsbookOutrightMatchDetailController>();
            var model = new CompanyWinLoss.Sportsbook.OutrightMatchDetail.QueryModel { SportType = 1, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }
        [Test]
        public void SportsbookSite()
        {
            var controller = container.GetInstance<SportsbookSiteController>();
            var model = new CompanyWinLoss.Sportsbook.Site.QueryModel { BetType = 1, SportType = 1, IsHedge = false, IsLive = 2, Site = "Credit", StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void UniversalBetType()
        {
            var controller = container.GetInstance<UniversalBetTypeController>();
            var model = new CompanyWinLoss.Universal.BetType.QueryModel { ProductId = 7, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }



        [Test]
        public void UniversalSite()
        {
            var controller = container.GetInstance<UniversalSiteController>();
            var model = new CompanyWinLoss.Universal.Site.QueryModel { BetType = 18000, Site = "Credit", StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void VirtualSportsBetType()
        {
            var controller = container.GetInstance<VirtualSportsBetTypeController>();
            var model = new CompanyWinLoss.VirtualSports.BetType.QueryModel { SportType = 180, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void VirtualSportsSportType()
        {
            var controller = container.GetInstance<VirtualSportsSportTypeController>();
            var model = new CompanyWinLoss.VirtualSports.SportType.QueryModel { StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }

        [Test]
        public void VirtualSportsSite()
        {
            var controller = container.GetInstance<VirtualSportsSiteController>();
            var model = new CompanyWinLoss.VirtualSports.Site.QueryModel { SportType = 180, BetType = 1203, Site = "Credit", StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }
        [Test]
        public void VirtualSportsRacingDetail()
        {
            var controller = container.GetInstance<VirtualSportsRacingDetailController>();
            var model = new CompanyWinLoss.VirtualSports.RacingDetail.QueryModel { BetType = 1231, SportType = 181, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }
        [Test]
        public void VirtualSportsSportsbookDetail()
        {
            var controller = container.GetInstance<VirtualSportsSportsbookDetailController>();
            var model = new CompanyWinLoss.VirtualSports.SportsbookDetail.QueryModel { BetType = 1203, SportType = 180, StartDate = startDate, EndDate = endDate, NormalMode = true };
            controller.Json(model);
        }
    }
}
