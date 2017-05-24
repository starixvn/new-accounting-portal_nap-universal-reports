using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.MatchDetail;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.MatchDetail
{
    public class WinLossUnitTests
    {
        [Test]
        [TestCase(12, 0, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1000.25, ExpectedResult = 0)]
        [TestCase(12, 100, ExpectedResult = 0.12)]
        [TestCase(-4.99, 5.55, ExpectedResult = -0.8991)]
        [TestCase(-4.9925, 5.5472, ExpectedResult = -0.9)]
        public decimal RealMargin_ShouldReturnRightMargin(decimal income, decimal turnover)
        {
            // Arrange
            var winLoss = new WinLoss { RealIncome = income, RealTurnover = turnover };

            // Assert
            return winLoss.RealMargin;
        }

        [Test]
        [TestCase(12, 0, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1000.25, ExpectedResult = 0)]
        [TestCase(12, 100, ExpectedResult = 0.12)]
        [TestCase(-4.99, 5.55, ExpectedResult = -0.8991)]
        [TestCase(-4.9925, 5.5472, ExpectedResult = -0.9)]
        public decimal VirtualMargin_ShouldReturnRightMargin(decimal income, decimal turnover)
        {
            // Arrange
            var winLoss = new WinLoss { VirtualIncome = income, VirtualTurnover = turnover };

            // Assert
            return winLoss.VirtualMargin;
        }
    }
}
