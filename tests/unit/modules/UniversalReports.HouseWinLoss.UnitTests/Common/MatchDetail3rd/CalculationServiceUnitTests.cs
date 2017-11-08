using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.MatchDetail3rd;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
using CommonServices = UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.MatchDetail3rd
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class CalculationServiceUnitTests
    {
        private CommonServices.RemotingRef3rdService remotingRefService;

        [OneTimeSetUp]
        public void SetUp()
        {
            remotingRefService = Substitute.For<CommonServices.RemotingRef3rdService>();
            remotingRefService.Get3rdTeamName(Arg.Any<int>()).Returns(string.Empty);
        }

        [Test]
        public void FromRawWinLoss_Should_Return_Right_WinLoss()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<RawWinLoss>("Common.MatchDetail3rd.CalculationService.data-1-fakeData");
            var expected = TestDataLoader.Load<WinLoss>("Common.MatchDetail3rd.CalculationService.data-1-expected");

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Assert
            var result = calculationService.FromRawWinLoss(fakeData);
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateSumWinLoss_Should_Return_Right_RawWinLoss_Sum()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("Common.MatchDetail3rd.CalculationService.data-2-fakeData");
            var expected = TestDataLoader.Load<WinLoss>("Common.MatchDetail3rd.CalculationService.data-2-expected");

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
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("Common.MatchDetail3rd.CalculationService.data-3-fakeData");
            var expected = TestDataLoader.Load<List<LeagueWinLoss>>("Common.MatchDetail3rd.CalculationService.data-3-expected");

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
            var AnyLeague = string.Empty;
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("Common.MatchDetail3rd.CalculationService.data-4-fakeData");
            var expected = TestDataLoader.Load<LeagueWinLoss>("Common.MatchDetail3rd.CalculationService.data-4-expected");

            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateLeague(fakeData, AnyLeague);

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}
