using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.GameBetType.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Game.Model
{
    public class BetTypeModelUnitTests
    {
        [Test]
        public void OperatorPlus_TwoGameBetTypeModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new GameBetTypeModel
            {
                BetTypeId = 1,
                BetTypeName = "Bet Type 1",
                NonLiveWinLoss = 100,
                NonLiveTurnover = 200,
                NonLiveBetCount = 2,
                LiveWinLoss = 200,
                LiveTurnover = 300,
                LiveBetCount = 3
            };

            var secondObject = new GameBetTypeModel
            {
                BetTypeId = 2,
                BetTypeName = "Bet Type 2",
                NonLiveWinLoss = 50,
                NonLiveTurnover = 100,
                NonLiveBetCount = 1,
                LiveWinLoss = 100,
                LiveTurnover = 150,
                LiveBetCount = 2
            };

            var expectedObject = new GameBetTypeModel
            {
                BetTypeId = 0,
                BetTypeName = string.Empty,
                NonLiveWinLoss = 150,
                NonLiveTurnover = 300,
                NonLiveBetCount = 3,
                LiveWinLoss = 300,
                LiveTurnover = 450,
                LiveBetCount = 5
            };

            // Act
            var sumObject = firstObject + secondObject;

            // Assert
            Assert.That(sumObject, IsDeeplyEqual.To(expectedObject));
        }
    }
}