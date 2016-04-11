using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetailServices
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class CalculationServiceUnitTests
    {
        [Test]
        public void CalulationMargin_Shoud_Return_Zero_When_Turnover_Is_Zero()
        {
            // Arrange
            const int Zero = 0;
            const int AnyIncome = 100;
            var refService = Substitute.For<CommonServices.RemotingRefService>();
            var calculationService = new MatchDetailCalculationServiceImp(refService);

            // Act
            var result = calculationService.CalculateMargin(AnyIncome, Zero);

            // Assert
            Assert.AreEqual(Zero, result);
        }

        [Test]
        public void CalulationMargin_Shoud_Return_Right_Margin()
        {
            // Arrange
            const decimal ExpectedMargin = 0.5m;
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            var calculationService = new MatchDetailCalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateMargin(1m, 2m);

            // Assert
            Assert.AreEqual(ExpectedMargin, result);
        }

        [Test]
        public void FromRawWinLoss_Should_Return_Right_WinLoss()
        {
            // Arrange
            var rawWinLoss = WinLossFactory.CreateRawWinLoss(1, 1, 1, 100, 10, 200, 400);
            var expectedWinLoss = WinLossFactory.CreateWinLoss(1, 1, 1, 100, 10, 200, 400, 0.5m);
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns(string.Empty);
            remotingRefService.GetLeagueName(Arg.Any<int>()).Returns(string.Empty);

            var calculationService = new MatchDetailCalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.FromRawWinLoss(rawWinLoss);

            // Assert
            var equal = WinLossComparison.AreEqual(result, expectedWinLoss);
            Assert.True(equal);
        }

        [Test]
        public void CalculateSumWinLoss_Should_Return_Right_RawWinLoss_Sum()
        {
            // Arrange
            var rawWinLoss = WinLossFactory.CreateFakeRawWinLoss();
            var expectedWinLossTotal = WinLossFactory.CreateWinLoss(0, 0, 0, 1000, 100, 2000, 4000, 0.5m);
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            var calculationService = new MatchDetailCalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateSumWinLoss(rawWinLoss);

            // Assert
            var equal = WinLossComparison.AreEqual(result, expectedWinLossTotal);
            Assert.True(equal);
        }

        [Test]
        public void CalculationLeague_Should_Return_Right_League()
        {
            // Arrange
            const int AnyLeagueId = 1;
            var fakeLeague = CreateFakeLeague();
            var expectedLeague = CreateExpectedLeagueWinLoss();
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns(string.Empty);
            remotingRefService.GetLeagueName(Arg.Any<int>()).Returns(string.Empty);

            var calculationService = new MatchDetailCalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateLeague(fakeLeague, AnyLeagueId);

            // Assert
            var equal = WinLossComparison.AreEqual(expectedLeague, result);
            Assert.True(equal);
        }

        private List<MatchDetailRawWinLoss> CreateFakeLeague()
        {
            var match1 = WinLossFactory.CreateRawWinLoss(1, 1, 1, 100, 10, 200, 400);
            var match2 = WinLossFactory.CreateRawWinLoss(2, 2, 1, 200, 20, 400, 800);

            return new List<MatchDetailRawWinLoss> { match1, match2 };
        }

        private LeagueWinLoss CreateExpectedLeagueWinLoss()
        {
            var matches = new List<MatchDetailWinLoss> {
                WinLossFactory.CreateWinLoss(1, 1, 1, 100, 10, 200, 400, 0.5m),
                WinLossFactory.CreateWinLoss(2, 2, 1, 200, 20, 400, 800, 0.5m)
            };

            var total = WinLossFactory.CreateWinLoss(0, 0, 1, 300, 30, 600, 1200, 0.5m);

            return new LeagueWinLoss
            {
                LeagueName = string.Empty,
                Matches = matches,
                Total = total
            };
        }
    }
}
