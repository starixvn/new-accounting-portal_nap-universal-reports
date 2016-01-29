using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.SportsbookMatchDetail
{
    public class CalculationServiceUnitTests
    {
        [Test]
        public void CalculateMargin_TurnoverIsZero_ReturnsZero()
        {
            // Arrange
            const int ZERO = 0;
            const int ANY_INCOME = 12312;
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateMargin(ZERO, ANY_INCOME);

            // Assert
            Assert.AreEqual(ZERO, result);
        }

        [Test]
        public void CalculateMargin_TurnoverIsNotZero_ReturnsTheDividend()
        {
            // Arrange
            const decimal EXPECTED_DIVIDEND = 0.1m;
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateMargin(10m, 1m);

            // Assert
            Assert.AreEqual(EXPECTED_DIVIDEND, result);
        }

        [Test]
        public void FromRawWinLoss_ReturnsCorrectTeamNameAndMargin()
        {
            // Arrange
            var rawWinLoss = WinLossFactory.CreateRawWinLoss("MatchCode 1", 1, 1, 100, 110, 10, 500, 600);
            var expectedWinLoss = WinLossFactory.CreateWinLoss("MatchCode 1", "AnyTeamId", "AnyTeamId", 100, 110, 10, 500, 600, 500m / 600);
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(1).Returns("AnyTeamId");
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.FromRawWinLoss(rawWinLoss);

            // Assert
            var equal = WinLossComparision.AreTwoWinLossEqual(expectedWinLoss, result);
            Assert.True(equal);
        }

        [Test]
        public void CalculateSum_ArrayWithTwoRawWinLosses_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = WinLossFactory.CreateWinLoss(null, "AnyTeamId", "AnyTeamId", 210, 230, 21, 1050, 1890, 1050m / 1890);

            var winlosses = new[]
            {
                WinLossFactory.CreateRawWinLoss("MatchCode 1", 1, 1, 100, 110, 10, 500, 900),
                WinLossFactory.CreateRawWinLoss("MatchCode 2", 2, 2, 110, 120, 11, 550, 990)
            };

            // Act
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>()).Returns("AnyTeamId");
            var calculationService = new CalculationServiceImp(remotingRefService);
            var result = calculationService.CalculateSumWinLoss(winlosses);

            // Assert
            var areEqual1 = WinLossComparision.AreTwoWinLossEqual(expectedSum, result);
            Assert.True(areEqual1);
        }
    }
}
