using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common
{
    public class CalculationServiceUnitTests
    {
        [Test]
        public void CalculateMargin_TurnoverIsZero_ReturnsZero()
        {
            // Arrange
            const int ZERO = 0;
            const int ANY_INCOME = 12312;
            var calculationService = new CalculationServiceImp();

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
            var calculationService = new CalculationServiceImp();

            // Act
            var result = calculationService.CalculateMargin(10m, 1m);

            // Assert
            Assert.AreEqual(EXPECTED_DIVIDEND, result);
        }

        [Test]
        public void FromRawWinLoss_ReturnsCorrectVarianceAndMargin()
        {
            // Arrange
            var rawWinLoss = WinLossFactory.CreateRawWinLoss(1, "Sportsbook", "Sportsbook Live", 100, 110, 10, 500, 600, 900, 1000);
            var expectedWinLoss = WinLossFactory.CreateWinLoss(1, "Sportsbook Live", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
            var calculationService = new CalculationServiceImp();

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
            var expectedSum = WinLossFactory.CreateRawWinLoss(1, "Casino", "Deposit", 210, 230, 21, 1050, 1260, 1890, 2100);
            var deposit1 = WinLossFactory.CreateRawWinLoss(1, "Casino", "Deposit", 100, 110, 10, 500, 600, 900, 1000);
            var deposit2 = WinLossFactory.CreateRawWinLoss(1, "Casino", "Deposit", 110, 120, 11, 550, 660, 990, 1100);

            var winlosses = new[] { deposit1, deposit2 };

            // Act
            var calculationService = new CalculationServiceImp();
            var result = calculationService.CalculateSum(winlosses);

            // Assert
            var areEqual1 = WinLossComparision.AreTwoRawWinLossEqual(expectedSum, result);
            Assert.True(areEqual1);
        }

        [Test]
        public void CalculateTotal_ReturnsRightTotalValue()
        {
            // Arrange
            var expectedTotal = WinLossFactory.CreateWinLoss(1, "Group 1", 210, 410, 30, 610, 810, -200, 2100, 2500, 610m / 2100, 810m / 2500);
            var calculationService = new CalculationServiceImp();

            // Act
            var deposit = WinLossFactory.CreateRawWinLoss(1, "Group 1", "Deposit", 100, 200, 10, 300, 400, 1000, 1200);
            var credit = WinLossFactory.CreateRawWinLoss(1, "Group 1", "Credit", 110, 210, 20, 310, 410, 1100, 1300);
            var rawWinLosses = new List<RawWinLoss> { deposit, credit };

            var result = calculationService.CalculateTotal("Group 1", rawWinLosses);

            // Assert
            var areEqual = WinLossComparision.AreTwoWinLossEqual(expectedTotal, result);
            Assert.True(areEqual);
        }

        [Test]
        public void CalculateGrandTotal_TwoGroups_ReturnRightGrandTotal()
        {
            // Arrange   
            var expectedGrandTotal = CreateExpectedGrandTotal();
            var fakeData = CreateFakeRawWinLoss();

            // Act 
            var service = new CalculationServiceImp();
            var result = service.CalculateGrandTotal("Grand Total", fakeData);

            // Assert
            var equal = WinLossComparision.AreTwoSiteWinLossSummaryEqual(expectedGrandTotal, result);
            Assert.True(equal);
        }

        private SiteWinLossSummary CreateExpectedGrandTotal()
        {
            return new SiteWinLossSummary
            {
                Credit = WinLossFactory.CreateWinLoss(1, "Credit", 200, 220, 20, 1000, 1200, -200, 1800, 2000, 5m / 9, 0.6m),
                Deposit = WinLossFactory.CreateWinLoss(1, "Deposit", 220, 240, 22, 1100, 1320, -220, 1980, 2200, 5m / 9, 0.6m),
                Total = WinLossFactory.CreateWinLoss(1, "Grand Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 5m / 9, 0.6m)
            };
        }

        private IEnumerable<RawWinLoss> CreateFakeRawWinLoss()
        {
            var group1 = CreateFakeRawGroupWinLoss(1, "Group 1");
            var group2 = CreateFakeRawGroupWinLoss(2, "Group 2");

            return (new List<List<RawWinLoss>> { group1, group2 })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeRawGroupWinLoss(int groupId, string groupName)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Credit", 100, 110, 10, 500, 600, 900, 1000);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Deposit", 110, 120, 11, 550, 660, 990, 1100);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        [Test]
        public void CalculateSiteWinLoss_MissingCreditAndDeposit_ReturnEmptySiteWinLoss()
        {
            // Arrange   
            var expectedGroup = CreateEmptySiteWinLoss();
            var fakeData = new List<RawWinLoss>();

            // Act 
            var service = new CalculationServiceImp();
            var result = service.CalculateSiteWinLossSummary(1, "Group 1", fakeData);

            // Assert
            var equal = WinLossComparision.AreTwoSiteWinLossSummaryEqual(expectedGroup, result);

            Assert.True(equal);
        }

        private SiteWinLossSummary CreateEmptySiteWinLoss()
        {
            return new SiteWinLossSummary
            {
                Credit = WinLossFactory.CreateWinLoss(1, "Credit", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                Deposit = WinLossFactory.CreateWinLoss(1, "Deposit", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                Total = WinLossFactory.CreateWinLoss(1, "Group 1", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
            };
        }

        [Test]
        public void CalculateGroupWinLoss_TwoGroups_ReturnRightGroups()
        {
            // Arrange   
            var expectedGroups = CreateExpectedGroups();
            var fakeData = CreateFakeRawWinLoss();

            // Act 
            var service = new CalculationServiceImp();
            var result = service.CalculateSiteWinLossSummary(fakeData).ToList();

            // Assert
            var equal1 = WinLossComparision.AreTwoSiteWinLossSummaryEqual(expectedGroups[0], result[0]);
            var equal2 = WinLossComparision.AreTwoSiteWinLossSummaryEqual(expectedGroups[1], result[1]);
            Assert.True(equal1);
            Assert.True(equal2);
        }

        private List<SiteWinLossSummary> CreateExpectedGroups()
        {
            var group1 = CreateExpectedGroup(1, "Group 1");
            var group2 = CreateExpectedGroup(2, "Group 2");

            return new List<SiteWinLossSummary> { group1, group2 };
        }

        private SiteWinLossSummary CreateExpectedGroup(int groupId, string groupName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(groupId, "Credit", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(groupId, "Deposit", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(groupId, groupName, 210, 230, 21, 1050, 1260, -210, 1890, 2100, 5m / 9, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }
    }
}
