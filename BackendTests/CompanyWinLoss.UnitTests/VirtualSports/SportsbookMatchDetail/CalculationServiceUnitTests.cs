using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.SportsbookMatchDetail
{
    public class CalculationServiceUnitTests
    {
        [Test]
        [Category("CompanyWinLossUnitTests")]
        public void CalculateMargin_TurnoverIsZero_ReturnsZero()
        {
            // Arrange
            const int Zero = 0;
            const int AnyIncome = 12312;
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateMargin(Zero, AnyIncome);

            // Assert
            Assert.AreEqual(Zero, result);
        }

        [Test]
        [Category("CompanyWinLossUnitTests")]
        public void CalculateMargin_TurnoverIsNotZero_ReturnsTheDividend()
        {
            // Arrange
            const decimal ExpectedDividend = 0.1m;
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculateMargin(10m, 1m);

            // Assert
            Assert.AreEqual(ExpectedDividend, result);
        }

        [Test]
        [Category("CompanyWinLossUnitTests")]
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
        [Category("CompanyWinLossUnitTests")]
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
