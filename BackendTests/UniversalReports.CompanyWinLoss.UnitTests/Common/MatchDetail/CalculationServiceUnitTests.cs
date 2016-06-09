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
        private CommonServices.RemotingRefService remotingRefService;

        [OneTimeSetUp]
        public void SetUp()
        {
            remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns(string.Empty);
            remotingRefService.GetLeagueName(Arg.Any<int>()).Returns(string.Empty);
        }

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
            ComparisonAssert.AreEqual(Zero, result);
        }

        [Test]
        public void CalulationMargin_Shoud_Return_Right_Margin()
        {
            // Arrange
            const decimal ExpectedMargin = 0.5m;
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
            var fakeData = TestDataLoader.Load<RawWinLoss>("data-1-fakeData");
            var expected = TestDataLoader.Load<WinLoss>("data-1-expected");

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Assert
            var result = calculationService.FromRawWinLoss(fakeData);
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateSumWinLoss_Should_Return_Right_RawWinLoss_Sum()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-2-fakeData");
            var expected = TestDataLoader.Load<WinLoss>("data-2-expected");

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateSumWinLoss(fakeData);

            // Assert
            ComparisonAssert.AreEqual(result, expected);
        }

        [Test]
        public void CalculationLeagues_Should_Return_Right_Leagues()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-3-fakeData");
            var expected = TestDataLoader.Load<List<LeagueWinLoss>>("data-3-expected");

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateLeagues(fakeData).ToList();

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculationLeague_Should_Return_Right_League()
        {
            // Arrange
            const int AnyLeagueId = 1;
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-4-fakeData");
            var expected = TestDataLoader.Load<LeagueWinLoss>("data-4-expected");

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateLeague(fakeData, AnyLeagueId);

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateRM_ShouldReturnRight_RM()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-5-fakeData");
            var expected = TestDataLoader.Load<List<WinLoss>>("data-5-expected");

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateRM(fakeData).ToList();

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateMatches_ShouldReturnRightMatches()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-6-fakeData");
            var expected = TestDataLoader.Load<List<WinLoss>>("data-6-expected");

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateMatches(fakeData).ToList();

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}
