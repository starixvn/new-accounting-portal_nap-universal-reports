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
        public void CalculateSum_TwoArrayWithTwoRawWinLosses_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss(1, 1, 1, 150, 15, 300, 300),
                WinLossFactory.CreateRawWinLoss(2, 2, 2, 150, 15, 300, 300)
            };

            var match1Source1 = WinLossFactory.CreateRawWinLoss(1, 1, 1, 100, 10, 200, 200);
            var match2Source1 = WinLossFactory.CreateRawWinLoss(2, 2, 2, 100, 10, 200, 200);
            var match1Source2 = WinLossFactory.CreateRawWinLoss(1, 1, 1, 50, 5, 100, 100);
            var match2Source2 = WinLossFactory.CreateRawWinLoss(2, 2, 2, 50, 5, 100, 100);

            var source1 = new[] { match1Source1, match2Source1 };
            var source2 = new[] { match1Source2, match2Source2 };
            var winlosses = new[] { source1, source2 };

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(winlosses).ToList();

            // Assert
            ComparisonExtension.AreEqual(expectedSum, result);
        }

        [Test]
        public void CalculateSum_ArrayWithTwoWinLosses_AndArrayWithOneWinLoss_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss(1, 1, 1, 150, 15, 300, 300),
                WinLossFactory.CreateRawWinLoss(2, 2, 2, 100, 10, 200, 200)
            };

            var match1Source1 = WinLossFactory.CreateRawWinLoss(1, 1, 1, 100, 10, 200, 200);
            var match2Source1 = WinLossFactory.CreateRawWinLoss(2, 2, 2, 100, 10, 200, 200);
            var match1Source2 = WinLossFactory.CreateRawWinLoss(1, 1, 1, 50, 5, 100, 100);

            var source1 = new[] { match1Source1, match2Source1 };
            var source2 = new[] { match1Source2 };
            var winlosses = new[] { source1, source2 };

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(winlosses).ToList();

            //// Assert
            ComparisonExtension.AreEqual(expectedSum, result);
        }
    }
}
