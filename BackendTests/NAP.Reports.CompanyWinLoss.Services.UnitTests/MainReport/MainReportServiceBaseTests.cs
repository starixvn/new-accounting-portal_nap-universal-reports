using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using NSubstitute;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests.MainReport
{
    public class MainReportServiceBaseTests
    {
        protected const string NumberGame = "Number Game";

        protected const string Sportsbook = "Sportsbook";

        private MainReportQuery _query;

        private IMainReportService _mainReportService;

        private ISportsbookWinLossService _sportsbookWinLossService;

        private IProductWinLossService _productWinLossService;

        public IProductWinLossService ProductWinLossService
        {
            get { return _productWinLossService; }
            set { _productWinLossService = value; }
        }

        public MainReportQuery Query
        {
            get { return _query; }
            set { _query = value; }
        }

        public IMainReportService MainReportService
        {
            get { return _mainReportService; }
            set { _mainReportService = value; }
        }

        public ISportsbookWinLossService SportsbookWinLossService
        {
            get { return _sportsbookWinLossService; }
            set { _sportsbookWinLossService = value; }
        }

        protected void Initialize()
        {
            var fakeSportsbookWinLossDetail = CreateFakeSportsbookWinLossDetail();
            var fakeSportsbookWinLoss = CreateFakeProductWinLoss(Sportsbook);
            var fakeNumberGameWinLoss = CreateFakeProductWinLoss(NumberGame);

            _query = new MainReportQuery();

            _sportsbookWinLossService = Substitute.For<ISportsbookWinLossService>();
            _productWinLossService = Substitute.For<IProductWinLossService>();

            _sportsbookWinLossService.Query(_query).Returns(fakeSportsbookWinLossDetail);
            _productWinLossService.Query(NumberGame, _query).Returns(fakeNumberGameWinLoss);
            _productWinLossService.Query(Sportsbook, _query).Returns(fakeSportsbookWinLoss);
        }

        private List<WinLoss> CreateFakeSportsbookWinLossDetail()
        {
            var liveWinLoss = WinLossFactory.CreateWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000, 400m / 1200);
            var nonLiveWinLoss = WinLossFactory.CreateWinLoss("Sportsbook Non-Live", 110, 210, 20, 310, 410, -100, 1100, 1300, 310m / 1100, 410m / 1300);
            var parlayWinLoss = WinLossFactory.CreateWinLoss("Parlay", 120, 220, 30, 320, 420, -100, 1200, 1400, 320m / 1200, 420m / 1400);
            var outrightWinLoss = WinLossFactory.CreateWinLoss("Outright", 130, 230, 40, 330, 430, -100, 1300, 1500, 330m / 1300, 430m / 1500);

            return new List<WinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }

        private ProductWinLoss CreateFakeProductWinLoss(string productName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss("Credit", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000m, 400m / 1200m);
            var depositWinLoss = WinLossFactory.CreateWinLoss("Deposit", 110, 210, 20, 310, 410, -100, 1100, 1300, 310m / 1100m, 410m / 1300m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(productName, 210, 410, 30, 610, 810, -200, 2100, 2500, 610m / 2100, 810m / 2500);
            return new ProductWinLoss
            {
                Credit = creditWinLoss,
                Deposit = depositWinLoss,
                Total = totalWinLoss
            };
        }
    }
}
