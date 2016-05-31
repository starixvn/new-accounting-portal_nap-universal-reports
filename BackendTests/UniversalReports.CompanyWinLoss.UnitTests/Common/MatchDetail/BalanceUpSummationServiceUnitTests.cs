using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.MatchDetail;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class BalanceUpSummationServiceUnitTests
    {
        [Test]
        public void CalculateSum_ArrayWithTwoWinLosses_AndArrayWithOneWinLoss_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = TestDataLoader.Load<List<RawWinLoss>>("data-1-expectedSum");
            var fakeData = TestDataLoader.Load<RawWinLoss[][]>("data-1-fakeData");

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(fakeData).ToList();

            //// Assert
            ComparisonAssert.AreEqual(expectedSum, result);
        }

        [Test]
        public void CalculateSum_TwoArrayWithTwoRawWinLosses_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = TestDataLoader.Load<List<RawWinLoss>>("data-2-expectedSum");
            var fakeData = TestDataLoader.Load<RawWinLoss[][]>("data-2-fakeData");

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(fakeData).ToList();

            // Assert
            ComparisonAssert.AreEqual(expectedSum, result);
        }       
    }
}
