using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.MatchDetail;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class CalculationServiceUnitTests
    {
        [Test]
        public void CalulationMargin_Shoud_Return_Zero_When_Turnover_Is_Zero()
        {
            // Arrange
            const decimal Zero = 0.0m;
            const int AnyIncome = 100;
            var refService = Substitute.For<CommonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(refService);

            // Act
            var result = calculationService.CalculateMargin(AnyIncome, Zero);

            // Assert
            ComparisonExtension.AreEqual(Zero, result);
        }

        [Test]
        public void CalulationMargin_Shoud_Return_Right_Margin()
        {
            // Arrange
            const decimal ExpectedMargin = 0.5m;
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(remotingRefService);

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

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.FromRawWinLoss(rawWinLoss);

            // Assert
            ComparisonExtension.AreEqual(expectedWinLoss, result);
        }

        [Test]
        public void CalculateSumWinLoss_Should_Return_Right_RawWinLoss_Sum()
        {
            // Arrange
            var rawWinLoss = WinLossFactory.CreateFakeRawWinLoss();
            var expectedWinLossTotal = WinLossFactory.CreateWinLoss(0, 0, 0, 1000, 100, 2000, 4000, 0.5m);
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateSumWinLoss(rawWinLoss);

            // Assert
            ComparisonExtension.AreEqual(result, expectedWinLossTotal);
        }

        [Test]
        public void CalculationLeagues_Should_Return_Right_Leagues()
        {
            // Arrange
            var fakeData = CreateFakeData();
            var expected = CreateExpectedLeagueWinLoss();
            var expectedList = new List<LeagueWinLoss> { expected };
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns(string.Empty);
            remotingRefService.GetLeagueName(Arg.Any<int>()).Returns(string.Empty);

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateLeagues(fakeData).ToList();

            // Assert
            ComparisonExtension.AreEqual(expectedList, result);
        }

        [Test]
        public void CalculationLeague_Should_Return_Right_League()
        {
            // Arrange
            const int AnyLeagueId = 1;
            var fakeLeague = CreateFakeData().Where(m => m.LeagueId > 0);
            var expected = CreateExpectedLeagueWinLoss();
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns(string.Empty);
            remotingRefService.GetLeagueName(Arg.Any<int>()).Returns(string.Empty);

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateLeague(fakeLeague, AnyLeagueId);

            // Assert
            ComparisonExtension.AreEqual(expected, result);
        }

        private List<RawWinLoss> CreateFakeData()
        {
            var match1 = WinLossFactory.CreateRawWinLoss(1, 1, 1, 100, 10, 200, 400);
            var match2 = WinLossFactory.CreateRawWinLoss(2, 2, 1, 200, 20, 400, 800);
            var matchRM = WinLossFactory.CreateRawWinLoss(0, 0, 0, 200, 20, 400, 800);

            return new List<RawWinLoss> { match1, match2, matchRM };
        }

        private LeagueWinLoss CreateExpectedLeagueWinLoss()
        {
            var matches = new List<WinLoss>
            {
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

        [Test]
        public void CalculateRM_ShouldReturnRight_RM()
        {
            // Arrange
            var fakeLeague = CreateFakeData();
            var expected = CreateExpectedRM();
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns(string.Empty);
            remotingRefService.GetLeagueName(Arg.Any<int>()).Returns(string.Empty);

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateRM(fakeLeague).ToList();

            // Assert
            ComparisonExtension.AreEqual(expected, result);
        }

        private List<WinLoss> CreateExpectedRM()
        {
            var winLoss = new WinLoss
            {
                MatchCode = string.Empty,
                AwayName = string.Empty,
                HomeName = string.Empty,
                LeagueName = string.Empty,
                MemberWinLoss = 200,
                SMAWinLoss = 200,
                Commission = 20,
                RealIncome = 400,
                VirtualIncome = 400,
                RealTurnover = 800,
                VirtualTurnover = 800,
                RealMargin = 0.5m,
                VarianceIncome = 0,
                VirtualMargin = 0.5m
            };

            return new List<WinLoss> { winLoss };
        }

        [Test]
        public void CalculateMatches_ShouldReturnRightMatches()
        {
            // Arrange
            var fakeData = CreateFakeData();
            var expected = CreateExpectedMatches();
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns(string.Empty);
            remotingRefService.GetLeagueName(Arg.Any<int>()).Returns(string.Empty);

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateMatches(fakeData).ToList();

            // Assert
            ComparisonExtension.AreEqual(expected, result);
        }

        private List<WinLoss> CreateExpectedMatches()
        {
            var match1 = WinLossFactory.CreateWinLoss(1, 1, 1, 100, 10, 200, 400, 0.5m);
            var match2 = WinLossFactory.CreateWinLoss(2, 2, 1, 200, 20, 400, 800, 0.5m);

            return new List<WinLoss> { match1, match2 };
        }
    }
}
