using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NUnit.Framework;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
{
    public class CalculationServiceUnitTests
    {
        private const string NumberGame = "Number Game";

        [Test]
        public void CalculateMargin_TurnoverIsZero_ReturnsZero()
        {
            // Arrange
            var zero = 0;
            var anyIncome = 12312;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.CalculateMargin(zero, anyIncome);

            // Assert
            Assert.AreEqual(zero, result);
        }

        [Test]
        public void CalculateMargin_TurnoverIsNotZero_ReturnsTheDividend()
        {
            // Arrange
            var expectedDevidend = 0.1m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.CalculateMargin(10m, 1m);

            // Assert
            Assert.AreEqual(expectedDevidend, result);
        }

        [Test]
        public void FromRawWinLoss_ReturnsCorrectVarianceAndMargin()
        {
            // Arrange
            var rawWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, 1000, 1200);
            var expectedWinLoss = WinLossFactory.CreateWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000m, 400m / 1200m);
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.FromRawWinLoss(rawWinLoss);

            // Assert
            var equal = WinLossComparision.AreTwoWinLossEqual(expectedWinLoss, result);
            Assert.True(equal);
        }

        [Test]
        public void CalculateTotal_ReturnsRightTotalValue()
        {
            // Arrange
            var expectedTotal = WinLossFactory.CreateWinLoss(NumberGame, 210, 410, 30, 610, 810, -200, 2100, 2500, 610.0m / 2100, 810.0m / 2500);
            var calculationService = new CalculationService();

            // Act
            var deposit = WinLossFactory.CreateWinLoss("Deposit", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000, 400m / 1200);
            var credit = WinLossFactory.CreateWinLoss("Credit", 110, 210, 20, 310, 410, -100, 1100, 1300, 310m / 1100, 410m / 1300);
            var result = calculationService.CalculateTotal(NumberGame, credit, deposit);

            // Assert
            var areEqual = WinLossComparision.AreTwoWinLossEqual(expectedTotal, result);
            Assert.True(areEqual);
        }

        [Test]
        public void CalculateSum_TwoWinLoss_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = WinLossFactory.CreateWinLoss("Deposit", 210, 410, 30, 610, 810, -200, 2100, 2500, 610.0m / 2100, 810.0m / 2500);
            var calculationService = new CalculationService();

            // Act
            var deposit1 = WinLossFactory.CreateWinLoss("Deposit", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000, 400m / 1200);
            var deposit2 = WinLossFactory.CreateWinLoss("Deposit", 110, 210, 20, 310, 410, -100, 1100, 1300, 310m / 1100, 410m / 1300);
            var winlosses = new WinLoss[] { deposit1, deposit2 };

            var result = calculationService.CalculateSum("Deposit", winlosses);

            // Assert
            var areEqual = WinLossComparision.AreTwoWinLossEqual(expectedSum, result);
            Assert.True(areEqual);
        }
    }
}
