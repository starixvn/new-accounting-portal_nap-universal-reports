using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Game.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Game.Model
{
    public class GameModelUnitTests
    {
        [Test]
        public void OperatorPlus_TwoGameModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new GameModel
            {
                LeagueGroupId = 1,
                LeagueGroupName = "League 1",
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };

            var secondObject = new GameModel
            {
                LeagueGroupId = 2,
                LeagueGroupName = "League 2",
                WinLoss = 200,
                Turnover = 300,
                BetCount = 3
            };

            var expectedObject = new GameModel
            {
                LeagueGroupId = 0,
                LeagueGroupName = string.Empty,
                WinLoss = 300,
                Turnover = 500,
                BetCount = 5
            };

            // Act
            var sumObject = firstObject + secondObject;

            // Assert
            Assert.That(sumObject, IsDeeplyEqual.To(expectedObject));
        }
    }
}