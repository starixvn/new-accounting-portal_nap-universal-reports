using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.Services
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class CalculationServiceUnitTests
    {
        [Test]
        public void FromRawWinLossByRowName_ReturnsCorrectVarianceAndMargin()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<WinLossRaw>("data-1-fakeData");
            var expected = TestDataLoader.Load<WinLoss>("data-1-expected");
            var calculationService = new CalculationServiceImp();

            // Act
            var result = calculationService.FromRawWinLossByRowName(fakeData);

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateSum_ArrayWithTwoRawWinLosses_ReturnsRightSumValue()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("data-2-fakeData");
            var expected = TestDataLoader.Load<WinLossRaw>("data-2-expected");

            // Act
            var calculationService = new CalculationServiceImp();
            var result = calculationService.CalculateSum(fakeData);

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateSumWinLoss_ReturnsRightTotalValue()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("data-3-fakeData");
            var expected = TestDataLoader.Load<WinLoss>("data-3-expected");

            var calculationService = new CalculationServiceImp();

            // Act
            var result = calculationService.CalculateSumWinLoss("Group 1", fakeData);

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateSumWinLossSummary_TwoGroups_ReturnRightGrandTotal()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("data-4-fakeData");
            var expected = TestDataLoader.Load<SiteWinLossSummary>("data-4-expected");

            // Act
            var service = new CalculationServiceImp();
            var result = service.CalculateSumWinLossSummary("Grand Total", fakeData);

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateSumWinLossSummary_EmptyData_ReturnZeroCreditAndDeposit()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("data-5-fakeData");
            var expected = TestDataLoader.Load<SiteWinLossSummary>("data-5-expected");

            // Act
            var service = new CalculationServiceImp();
            var result = service.CalculateSumWinLossSummary("Grand Total", fakeData);

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateSiteWinLossSummary_EmptyData_ReturnEmptySiteWinLoss()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("data-6-fakeData");
            var expected = TestDataLoader.Load<SiteWinLossSummary>("data-6-expected");

            // Act
            var service = new CalculationServiceImp();
            var result = service.CalculateSiteWinLossSummary(1, "Group 1", fakeData);

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateSiteWinLossSummary_TwoGroups_ReturnRightGroups()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("data-7-fakeData");
            var expected = TestDataLoader.Load<List<SiteWinLossSummary>>("data-7-expected");

            // Act
            var service = new CalculationServiceImp();
            var result = service.CalculateSiteWinLossSummary(fakeData).ToList();

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateRM_ReturnRightRMData()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("data-8-fakeData");
            var expected = TestDataLoader.Load<List<WinLoss>>("data-8-expected");

            // Act
            var service = new CalculationServiceImp();
            var result = service.CalculateRM(fakeData).ToList();

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}