using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.SportType.Model
{
    public class SportTypeModelUnitTests
    {
        [Test]
        public void OperatorPlus_TwoSportTypeModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new SportTypeModel
            {
                SportType = "Sport 1",
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };

            var secondObject = new SportTypeModel
            {
                SportType = "Sport 2",
                WinLoss = 200,
                Turnover = 300,
                BetCount = 3
            };

            var expectedObject = new SportTypeModel
            {
                SportType = string.Empty,
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
