using NAP.Reports.CompanyWinLoss.Models;
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
            var rawWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook", "Sportsbook Live", 100, 110, 10, 500, 600, 900, 1000);
            var expectedWinLoss = WinLossFactory.CreateWinLoss("Sportsbook Live", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
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
                WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 210, 230, 21, 1050, 1260, 1890, 2100),
                WinLossFactory.CreateRawWinLoss("Casino", "Credit", 210, 230, 21, 1050, 1260, 1890, 2100),
            };

            var deposit1 = WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 100, 110, 10, 500, 600, 900, 1000);
            var deposit2 = WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 110, 120, 11, 550, 660, 990, 1100);
            var credit1 = WinLossFactory.CreateRawWinLoss("Casino", "Credit", 100, 110, 10, 500, 600, 900, 1000);
            var credit2 = WinLossFactory.CreateRawWinLoss("Casino", "Credit", 110, 120, 11, 550, 660, 990, 1100);

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
            var expectedSum = WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 210, 230, 21, 1050, 1260, 1890, 2100);
            var deposit1 = WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 100, 110, 10, 500, 600, 900, 1000);
            var deposit2 = WinLossFactory.CreateRawWinLoss("Casino", "Deposit", 110, 120, 11, 550, 660, 990, 1100);

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

        [Test]
        [Category("ServiceUnitTests")]
        public void CalculateGrandTotal_SportsbookAndNumberGame_ReturnRightGrandTotal()
        {
            // Arrange   
            var expectedGrandTotal = CreateExpectedGrandTotal();
            var calculationService = new CalculationService();
            var fakeData = CreateFakeRawWinLoss();

            // Act 
            var service = new CalculationService();
            var result = service.CalculateGrandTotal(fakeData);

            // Assert
            var equal = WinLossComparision.AreTwoSiteWinLossEqual(expectedGrandTotal, result);
            Assert.True(equal);
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var sportsbook = CreateFakeRawGroupWinLoss("Sportsbook");
            var numberGame = CreateFakeRawGroupWinLoss("Number Game");

            return (new List<List<RawWinLoss>> { sportsbook, numberGame })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeRawGroupWinLoss(string productName)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(productName, "Credit", 100, 110, 10, 500, 600, 900, 1000);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(productName, "Deposit", 110, 120, 11, 550, 660, 990, 1100);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        [Test]
        [Category("ServiceUnitTests")]
        public void CalculateGroupWinLoss_SportsbookAndNumberGame_ReturnRightGroupss()
        {
            // Arrange   
            var expectedGroups = CreateExpectedGroups();
            var calculationService = new CalculationService();
            var fakeData = CreateFakeRawWinLoss();

            // Act 
            var service = new CalculationService();
            var result = service.CalculateGroupWinLoss(fakeData).ToList();

            // Assert
            var equal1 = WinLossComparision.AreTwoSiteWinLossEqual(expectedGroups[0], result[0]);
            var equal2 = WinLossComparision.AreTwoSiteWinLossEqual(expectedGroups[1], result[1]);
            Assert.True(equal1);
            Assert.True(equal2);
        }

        private SiteWinLoss CreateExpectedGrandTotal()
        {
            return new SiteWinLoss
            {
                Credit = WinLossFactory.CreateWinLoss("Credit", 200, 220, 20, 1000, 1200, -200, 1800, 2000, 5m / 9, 0.6m),
                Deposit = WinLossFactory.CreateWinLoss("Deposit", 220, 240, 22, 1100, 1320, -220, 1980, 2200, 5m / 9, 0.6m),
                Total = WinLossFactory.CreateWinLoss("Grand Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 5m / 9, 0.6m),
            };
        }

        private List<SiteWinLoss> CreateExpectedGroups()
        {
            var sportsbook = CreateExpectedGroup("Sportsbook");
            var numberGame = CreateExpectedGroup("Number Game");

            return new List<SiteWinLoss> { sportsbook, numberGame };
        }

        private SiteWinLoss CreateExpectedGroup(string groupName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss("Credit", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss("Deposit", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(groupName, 210, 230, 21, 1050, 1260, -210, 1890, 2100, 5m / 9, 0.6m);

            return new SiteWinLoss { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }
    }
}
