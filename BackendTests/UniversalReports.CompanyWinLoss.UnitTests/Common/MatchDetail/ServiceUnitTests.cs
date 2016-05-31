using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetail;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;
using commonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_Should_Return_Right_MatchDetail()
        {
            // Arrange
            var fakeWinLoss = WinLossFactory.CreateFakeRawWinLoss();
            var expected = CreateExpectedWinLossModel();
            var rawService = Substitute.For<RawWinLossService>();
            rawService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeWinLoss);

            var refService = Substitute.For<commonServices.RemotingRefService>();
            refService.GetLeagueName(Arg.Any<int>()).Returns(string.Empty);
            refService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns(string.Empty);
            var calculationService = new CalculationServiceImp(refService);

            // Act
            var service = new WinLossServiceImp(rawService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            ComparisonExtension.AreEqual(expected, result);
        }

        private WinLossModel CreateExpectedWinLossModel()
        {
            var match1 = WinLossFactory.CreateWinLoss(1, 1, 1, 100, 10, 200, 400, 0.5m);
            var match2 = WinLossFactory.CreateWinLoss(2, 2, 1, 200, 20, 400, 800, 0.5m);
            var match3 = WinLossFactory.CreateWinLoss(3, 3, 1, 300, 30, 600, 1200, 0.5m);
            var match4 = WinLossFactory.CreateWinLoss(4, 4, 1, 400, 40, 800, 1600, 0.5m);

            var matches = new List<WinLoss>
            {
                match1, match2, match3, match4
            };

            var league = new LeagueWinLoss
            {
                LeagueName = string.Empty,
                Matches = matches,
                Total = WinLossFactory.CreateWinLoss(0, 0, 1, 1000, 100, 2000, 4000, 0.5m),
            };

            var leagues = new List<LeagueWinLoss> { league };
            return new WinLossModel
            {
                Leagues = leagues,
                RM = CreateExpectedRM(),
                Total = WinLossFactory.CreateWinLoss(0, 0, 0, 1000, 100, 2000, 4000, 0.5m)
            };
        }

        private List<WinLoss> CreateExpectedRM()
        {
            var rm = WinLossFactory.CreateWinLoss(0, 0, 0, 100, 10, 200, 400, 0.5m);
            return new List<WinLoss> { rm };
        }
    }
}
