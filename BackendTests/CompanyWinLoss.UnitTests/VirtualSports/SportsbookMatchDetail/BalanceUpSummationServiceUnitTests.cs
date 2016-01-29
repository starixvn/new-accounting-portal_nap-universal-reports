using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.SportsbookMatchDetail
{
    public class BalanceUpSummationServiceUnitTests
    {
        [Test]
        public void CalculateSum_TwoArrayWithTwoRawWinLosses_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss("MatchCode 1", 1, 1, 200, 220, 20, 1000, 1800),
                WinLossFactory.CreateRawWinLoss("MatchCode 2", 2, 2, 220, 240, 22, 1100, 1980)
            };

            var match1Source1 = WinLossFactory.CreateRawWinLoss("MatchCode 1", 1, 1, 100, 110, 10, 500, 900);
            var match2Source1 = WinLossFactory.CreateRawWinLoss("MatchCode 2", 2, 2, 110, 120, 11, 550, 990);
            var match1Source2 = WinLossFactory.CreateRawWinLoss("MatchCode 1", 1, 1, 100, 110, 10, 500, 900);
            var match2Source2 = WinLossFactory.CreateRawWinLoss("MatchCode 2", 2, 2, 110, 120, 11, 550, 990);

            var source1 = new[] { match1Source1, match2Source1 };
            var source2 = new[] { match1Source2, match2Source2 };
            var winlosses = new[] { source1, source2 };

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(winlosses).ToList();

            // Assert
            var areEqual1 = WinLossComparision.AreTwoRawWinLossEqual(expectedSum[0], result[0]);
            var areEqual2 = WinLossComparision.AreTwoRawWinLossEqual(expectedSum[1], result[1]);

            Assert.True(areEqual1);
            Assert.True(areEqual2);
        }

        [Test]
        public void CalculateSum_ArrayWithTwoWinLosses_AndArrayWithOneWinLoss_ReturnsRightSumValue()
        {
            // Arrange
            var expectedSum = new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss("MatchCode 1", 1, 1, 200, 220, 20, 1000, 1800),
                WinLossFactory.CreateRawWinLoss("MatchCode 2", 2, 2, 110, 120, 11, 550,  990)
            };

            var match1Source1 = WinLossFactory.CreateRawWinLoss("MatchCode 1", 1, 1, 100, 110, 10, 500, 900);
            var match2Source1 = WinLossFactory.CreateRawWinLoss("MatchCode 2", 2, 2, 110, 120, 11, 550, 990);
            var match1Source2 = WinLossFactory.CreateRawWinLoss("MatchCode 1", 1, 1, 100, 110, 10, 500, 900);

            var source1 = new[] { match1Source1, match2Source1 };
            var source2 = new[] { match1Source2 };
            var winlosses = new[] { source1, source2 };

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(winlosses).ToList();

            // Assert
            var areEqual1 = WinLossComparision.AreTwoRawWinLossEqual(expectedSum[0], result[0]);
            var areEqual2 = WinLossComparision.AreTwoRawWinLossEqual(expectedSum[1], result[1]);

            Assert.True(areEqual1);
            Assert.True(areEqual2);
        }
    }
}
