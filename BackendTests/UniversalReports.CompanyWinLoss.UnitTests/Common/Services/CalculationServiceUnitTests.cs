using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.Services
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class CalculationServiceUnitTests
    {
        [Test]
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
        public void FromRawWinLossByRowName_ReturnsCorrectVarianceAndMargin()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<RawWinLoss>("data-1-fakeData");
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
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-2-fakeData");
            var expected = TestDataLoader.Load<RawWinLoss>("data-2-expected");

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
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-3-fakeData");
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
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-4-fakeData");
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
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-5-fakeData");
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
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-6-fakeData");
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
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-7-fakeData");
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
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-8-fakeData");
            var expected = TestDataLoader.Load<List<WinLoss>>("data-8-expected");

            // Act 
            var service = new CalculationServiceImp();
            var result = service.CalculateRM(fakeData).ToList();

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}
