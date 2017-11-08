using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.MatchDetail3rd;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.MatchDetail3rd
{
    public class RawWinLossUnitTests
    {
        [Test]
        public void Add_ShouldReturnRightSumValue()
        {
            // Arrange
            var firstWinLoss = new RawWinLoss
            {
                League = "Any league",
                MatchCode = string.Empty,
                HomeId = 1,
                AwayId = 1,
                MemberWinLoss = 100m,
                SMAWinLoss = 100m,
                Commission = 10m,
                RealIncome = 200m,
                RealTurnover = 400m
            };

            var secondWinLoss = new RawWinLoss
            {
                League = "Any league 1",
                MatchCode = string.Empty,
                HomeId = 2,
                AwayId = 2,
                MemberWinLoss = 200m,
                SMAWinLoss = 200m,
                Commission = 20m,
                RealIncome = 400m,
                RealTurnover = 800m
            };

            var expectedWinLoss = new RawWinLoss
            {
                League = string.Empty,
                MatchCode = string.Empty,
                HomeId = 0,
                AwayId = 0,
                MemberWinLoss = 300m,
                SMAWinLoss = 300m,
                Commission = 30m,
                RealIncome = 600m,
                RealTurnover = 1200m
            };

            // Assert
            var sumWinLoss = firstWinLoss + secondWinLoss;
            Assert.That(sumWinLoss, IsDeeplyEqual.To(expectedWinLoss));
        }
    }
}
