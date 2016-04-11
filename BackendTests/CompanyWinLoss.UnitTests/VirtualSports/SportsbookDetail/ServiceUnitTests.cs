using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetailServices;
using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;
using SportsbookDetails = UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.SportsbookDetail
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightMatchDetailWinLoss()
        {
            // Arrange   
            var expected = CreateExpectedWinLossModel();

            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns(string.Empty);
            remotingRefService.GetLeagueName(Arg.Any<int>()).Returns(string.Empty);

            var calculationService = new MatchDetailCalculationServiceImp(remotingRefService);
            var rawWinLossService = Substitute.For<MatchDetailRawWinLossService>();
            var fakeWinLoss = WinLossFactory.CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeWinLoss);

            // Act 
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = AreEqual(expected, result);
            Assert.True(equal);
        }

        private SportsbookDetails.WinLossModel CreateExpectedWinLossModel()
        {
            var match1 = WinLossFactory.CreateWinLoss(1, 1, 1, 100, 10, 200, 400, 0.5m);
            var match2 = WinLossFactory.CreateWinLoss(2, 2, 1, 200, 20, 400, 800, 0.5m);
            var match3 = WinLossFactory.CreateWinLoss(3, 3, 1, 300, 30, 600, 1200, 0.5m);
            var match4 = WinLossFactory.CreateWinLoss(4, 4, 1, 400, 40, 800, 1600, 0.5m);

            var matches = new List<MatchDetailWinLoss>
            {
                match1, match2, match3, match4
            };

            return new SportsbookDetails.WinLossModel
            {
                Matches = matches,
                Total = WinLossFactory.CreateWinLoss(0, 0, 0, 1000, 100, 2000, 4000, 0.5m)
            };
        }

        private bool AreEqual(SportsbookDetails.WinLossModel expected, SportsbookDetails.WinLossModel model)
        {
            return WinLossComparison.AreEqual(expected.Total, model.Total)
                && WinLossComparison.AreEqual(expected.Matches, model.Matches);
        }
    }
}
