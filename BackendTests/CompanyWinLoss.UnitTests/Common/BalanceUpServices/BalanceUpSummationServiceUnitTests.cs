using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.BalanceUpServices
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class BalanceUpSummationServiceUnitTests
    {
        [Test]
        public void CalculateSum_TwoArrayWithTwoRawWinLosses_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss(1, "Casino", "Deposit", 210, 230, 21, 1050, 1260, 100, 100, 100, 1890, 2100),
                WinLossFactory.CreateRawWinLoss(1, "Casino", "Credit", 210, 230, 21, 1050, 1260, 100, 100, 100, 1890, 2100)
            };

            var deposit1 = WinLossFactory.CreateRawWinLoss(1, "Casino", "Deposit", 100, 110, 10, 500, 600, 100, 100, 100, 900, 1000);
            var deposit2 = WinLossFactory.CreateRawWinLoss(1, "Casino", "Deposit", 110, 120, 11, 550, 660, 100, 100, 100, 990, 1100);
            var credit1 = WinLossFactory.CreateRawWinLoss(1, "Casino", "Credit", 100, 110, 10, 500, 600, 100, 100, 100, 900, 1000);
            var credit2 = WinLossFactory.CreateRawWinLoss(1, "Casino", "Credit", 110, 120, 11, 550, 660, 100, 100, 100, 990, 1100);

            var group1 = new[] { deposit1, credit1 };
            var group2 = new[] { deposit2, credit2 };
            var winlosses = new[] { group1, group2 };

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(winlosses).ToList();

            // Assert
            var areEqual1 = Comparison.AreEqual(expectedSum[0], result[0]);
            var areEqual2 = Comparison.AreEqual(expectedSum[1], result[1]);

            Assert.True(areEqual1);
            Assert.True(areEqual2);
        }

        [Test]
        public void CalculateSum_ArrayWithTwoWinLosses_AndArrayWithOneWinLoss_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss(1, "Casino", "Deposit", 210, 230, 21, 1050, 1260, 100, 100, 100, 1890, 2100),
                WinLossFactory.CreateRawWinLoss(1, "Casino", "Credit",  100, 110, 10, 500, 600, 100, 100, 100, 900, 1000)
            };

            var deposit1 = WinLossFactory.CreateRawWinLoss(1, "Casino", "Deposit", 100, 110, 10, 500, 600, 100, 100, 100, 900, 1000);
            var deposit2 = WinLossFactory.CreateRawWinLoss(1, "Casino", "Deposit", 110, 120, 11, 550, 660, 100, 100, 100, 990, 1100);
            var credit1 = WinLossFactory.CreateRawWinLoss(1, "Casino", "Credit", 100, 110, 10, 500, 600, 100, 100, 100, 900, 1000);

            var group1 = new[] { deposit1, credit1 };
            var group2 = new[] { deposit2 };
            var winlosses = new[] { group1, group2 };

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(winlosses).ToList();

            // Assert
            var areEqual1 = Comparison.AreEqual(expectedSum[0], result[0]);
            var areEqual2 = Comparison.AreEqual(expectedSum[1], result[1]);

            Assert.True(areEqual1);
            Assert.True(areEqual2);
        }
    }
}
