using NAP.Reports.CompanyWinLoss.Services.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
{
    public class CalculationServiceUnitTests
    {
        private const string NumberGame = "Number Game";

        [Test]
        [Category("CalculationServiceUnitTests")]
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
        [Category("CalculationServiceUnitTests")]
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
        [Category("CalculationServiceUnitTests")]
        public void FromRawWinLoss_ReturnsCorrectVarianceAndMargin()
        {
            // Arrange
            var rawWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook", "Sportsbook Live", 100, 200, 10, 300, 400, 1000, 1200);
            var expectedWinLoss = WinLossFactory.CreateWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000m, 400m / 1200m);
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.FromRawWinLoss(rawWinLoss);

            // Assert
            var equal = WinLossComparision.AreTwoWinLossEqual(expectedWinLoss, result);
            Assert.True(equal);
        }

        [Test]
        [Category("CalculationServiceUnitTests")]
        public void CalculateSum_TwoArrayWithTwoRawWinLosses_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 210, 410, 30, 610, 810, 2100, 2500),
                WinLossFactory.CreateRawWinLoss("Casino", "Credit", 210, 410, 30, 610, 810, 2100, 2500),
            };

            var deposit1 = WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 100, 200, 10, 300, 400, 1000, 1200);
            var deposit2 = WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 110, 210, 20, 310, 410, 1100, 1300);
            var credit1 = WinLossFactory.CreateRawWinLoss("Casino", "Credit", 100, 200, 10, 300, 400, 1000, 1200);
            var credit2 = WinLossFactory.CreateRawWinLoss("Casino", "Credit", 110, 210, 20, 310, 410, 1100, 1300);

            var group1 = new RawWinLoss[] { deposit1, credit1 };
            var group2 = new RawWinLoss[] { deposit2, credit2 };
            var winlosses = new[] { group1, group2 };

            // Act
            var calculationService = new CalculationService();
            var result = calculationService.CalculateSum(winlosses).ToList();

            // Assert
            var areEqual1 = WinLossComparision.AreTwoRawWinLossEqual(expectedSum[0], result[0]);
            var areEqual2 = WinLossComparision.AreTwoRawWinLossEqual(expectedSum[1], result[1]);
            Assert.True(areEqual1);
            Assert.True(areEqual2);
        }

        [Test]
        [Category("CalculationServiceUnitTests")]
        public void CalculateSum_ArrayWithTwoRawWinLosses_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 210, 410, 30, 610, 810, 2100, 2500);
            var deposit1 = WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 100, 200, 10, 300, 400, 1000, 1200);
            var deposit2 = WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 110, 210, 20, 310, 410, 1100, 1300);

            var winlosses = new RawWinLoss[] { deposit1, deposit2 };

            // Act
            var calculationService = new CalculationService();
            var result = calculationService.CalculateSum(winlosses);

            // Assert
            var areEqual1 = WinLossComparision.AreTwoRawWinLossEqual(expectedSum, result);

            Assert.True(areEqual1);
        }

        [Test]
        [Category("CalculationServiceUnitTests")]
        public void CalculateTotal_ReturnsRightTotalValue()
        {
            // Arrange
            var expectedTotal = WinLossFactory.CreateWinLoss(NumberGame, 210, 410, 30, 610, 810, -200, 2100, 2500, 610m / 2100, 810m / 2500);
            var calculationService = new CalculationService();

            // Act
            var deposit = WinLossFactory.CreateWinLoss("Deposit", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000, 400m / 1200);
            var credit = WinLossFactory.CreateWinLoss("Credit", 110, 210, 20, 310, 410, -100, 1100, 1300, 310m / 1100, 410m / 1300);
            var result = calculationService.CalculateTotal(NumberGame, credit, deposit);

            // Assert
            var areEqual = WinLossComparision.AreTwoWinLossEqual(expectedTotal, result);
            Assert.True(areEqual);
        }
    }
}
