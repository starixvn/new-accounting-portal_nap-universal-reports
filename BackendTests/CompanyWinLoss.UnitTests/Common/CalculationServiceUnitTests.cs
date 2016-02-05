using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common
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
            var calculationService = new CalculationServiceImp();

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
            var calculationService = new CalculationServiceImp();

            // Act
            var result = calculationService.CalculateMargin(10m, 1m);

            // Assert
            Assert.AreEqual(ExpectedDividend, result);
        }

        [Test]
        [Category("CompanyWinLossUnitTests")]
        public void FromRawWinLossByRowName_ReturnsCorrectVarianceAndMargin()
        {
            // Arrange
            var rawWinLoss = WinLossFactory.CreateRawWinLoss(1, "Sportsbook", "Sportsbook Live", 100, 110, 10, 500, 600, 900, 1000);
            var expectedWinLoss = WinLossFactory.CreateWinLoss(1, "Sportsbook Live", 100, 110, 10, 500, 600, -100, 900, 1000, 500m / 900, 600m / 1000);
            var calculationService = new CalculationServiceImp();

            // Act
            var result = calculationService.FromRawWinLossByRowName(rawWinLoss);

            // Assert
            var equal = WinLossComparision.AreTwoWinLossEqual(expectedWinLoss, result);
            Assert.True(equal);
        }

        [Test]
        [Category("CompanyWinLossUnitTests")]
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
        [Category("CompanyWinLossUnitTests")]
        public void CalculateSumWinLoss_ReturnsRightTotalValue()
        {
            // Arrange
            var expectedTotal = WinLossFactory.CreateWinLoss(1, "Group 1", 210, 410, 30, 610, 810, -200, 2100, 2500, 610m / 2100, 810m / 2500);
            var calculationService = new CalculationServiceImp();

            // Act
            var deposit = WinLossFactory.CreateRawWinLoss(1, "Group 1", "Deposit", 100, 200, 10, 300, 400, 1000, 1200);
            var credit = WinLossFactory.CreateRawWinLoss(1, "Group 1", "Credit", 110, 210, 20, 310, 410, 1100, 1300);
            var rawWinLosses = new List<RawWinLoss> { deposit, credit };

            var result = calculationService.CalculateSumWinLoss("Group 1", rawWinLosses);

            // Assert
            var areEqual = WinLossComparision.AreTwoWinLossEqual(expectedTotal, result);
            Assert.True(areEqual);
        }

        [Test]
        [Category("CompanyWinLossUnitTests")]
        public void CalculateSumWinLossSummary_TwoGroups_ReturnRightGrandTotal()
        {
            // Arrange   
            var expectedGrandTotal = CreateExpectedGrandTotal();
            var fakeData = CreateFakeRawWinLoss();

            // Act 
            var service = new CalculationServiceImp();
            var result = service.CalculateSumWinLossSummary("Grand Total", fakeData);

            // Assert
            var equal = WinLossComparision.AreTwoSiteWinLossSummaryEqual(expectedGrandTotal, result);
            Assert.True(equal);
        }

        private SiteWinLossSummary CreateExpectedGrandTotal()
        {
            return new SiteWinLossSummary
            {
                Credit = WinLossFactory.CreateWinLoss(1, "Credit", 200, 220, 20, 1000, 1200, -200, 1800, 2000, 1000m / 1800, 1200m / 2000),
                Deposit = WinLossFactory.CreateWinLoss(1, "Deposit", 220, 240, 22, 1100, 1320, -220, 1980, 2200, 1100m / 1980, 1320m / 2200),
                Total = WinLossFactory.CreateWinLoss(1, "Grand Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 2100m / 3780, 2520m / 4200)
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
        [Category("CompanyWinLossUnitTests")]
        public void CalculateSiteWinLossSummary_MissingCreditAndDeposit_ReturnEmptySiteWinLoss()
        {
            // Arrange   
            var expectedGroup = CreateEmptySiteWinLoss();

            // Act 
            var service = new CalculationServiceImp();
            var result = service.CalculateSiteWinLossSummary(1, "Group 1", new List<RawWinLoss>());

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
        [Category("CompanyWinLossUnitTests")]
        public void CalculateSiteWinLossSummary_TwoGroups_ReturnRightGroups()
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
            var creditWinLoss = WinLossFactory.CreateWinLoss(groupId, "Credit", 100, 110, 10, 500, 600, -100, 900, 1000, 500m / 900, 600m / 1000);
            var depositWinLoss = WinLossFactory.CreateWinLoss(groupId, "Deposit", 110, 120, 11, 550, 660, -110, 990, 1100, 550m / 990, 660m / 1100);
            var totalWinLoss = WinLossFactory.CreateWinLoss(groupId, groupName, 210, 230, 21, 1050, 1260, -210, 1890, 2100, 1050m / 1890, 1260m / 2100);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }
    }
}
