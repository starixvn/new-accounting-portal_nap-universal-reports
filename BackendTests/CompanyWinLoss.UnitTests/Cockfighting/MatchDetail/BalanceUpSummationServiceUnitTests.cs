using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail;

namespace UniversalReports.CompanyWinLoss.UnitTests.Cockfighting.MatchDetail
{
    [TestFixture]
    public class BalanceUpSummationServiceUnitTests
    {
        [Test]
        public void CalculateSum_TwoArrayWithTwoRawWinLosses_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss("match1", 1, "Home1", "Away1", 200, 220, 20, 1000, 1800),
                WinLossFactory.CreateRawWinLoss("match2", 2, "Home2", "Away2", 220, 240, 22, 1100, 1980)
            };

            var match1Source1 = WinLossFactory.CreateRawWinLoss("match1", 1, "Home1", "Away1", 100, 110, 10, 500, 900);
            var match2Source1 = WinLossFactory.CreateRawWinLoss("match2", 2, "Home2", "Away2", 110, 120, 11, 550, 990);
            var match1Source2 = WinLossFactory.CreateRawWinLoss("match1", 1, "Home1", "Away1", 100, 110, 10, 500, 900);
            var match2Source2 = WinLossFactory.CreateRawWinLoss("match2", 2, "Home2", "Away2", 110, 120, 11, 550, 990);

            var source1 = new[] { match1Source1, match2Source1 };
            var source2 = new[] { match1Source2, match2Source2 };
            var winlosses = new[] { source1, source2 };

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(winlosses).ToList();

            // Assert
            var areEqual1 = WinLossComparison.CompareTwoRawWinLossIsEqual(expectedSum[0], result[0]);
            var areEqual2 = WinLossComparison.CompareTwoRawWinLossIsEqual(expectedSum[1], result[1]);

            Assert.True(areEqual1);
            Assert.True(areEqual2);
        }

        [Test]
        public void CalculateSum_ArrayWithTwoWinLosses_AndArrayWithOneWinLoss_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss("match1", 1, "Home1", "Away1", 200, 220, 20, 1000, 1800),
                WinLossFactory.CreateRawWinLoss("match2", 2, "Home2", "Away2", 110, 120, 11, 550,  990)
            };

            var match1Source1 = WinLossFactory.CreateRawWinLoss("match1", 1, "Home1", "Away1", 100, 110, 10, 500, 900);
            var match2Source1 = WinLossFactory.CreateRawWinLoss("match2", 2, "Home2", "Away2", 110, 120, 11, 550, 990);
            var match1Source2 = WinLossFactory.CreateRawWinLoss("match1", 1, "Home1", "Away1", 100, 110, 10, 500, 900);

            var source1 = new[] { match1Source1, match2Source1 };
            var source2 = new[] { match1Source2 };
            var winlosses = new[] { source1, source2 };

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(winlosses).ToList();

            // Assert
            var areEqual1 = WinLossComparison.CompareTwoRawWinLossIsEqual(expectedSum[0], result[0]);
            var areEqual2 = WinLossComparison.CompareTwoRawWinLossIsEqual(expectedSum[1], result[1]);

            Assert.True(areEqual1);
            Assert.True(areEqual2);
        }
    }
}
