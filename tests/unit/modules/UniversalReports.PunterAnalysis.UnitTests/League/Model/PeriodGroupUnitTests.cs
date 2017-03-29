using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.League.Model
{
    public class PeriodGroupUnitTests
    {
        [Test]
        public void OperatorPlus_TwoPeriodGroups_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new PeriodGroup
            {
                WinLoss = 300,
                Turnover = 500,
                BetCount = 5
            };

            var secondObject = new PeriodGroup
            {
                WinLoss = 150,
                Turnover = 250,
                BetCount = 3
            };

            var expectedObject = new PeriodGroup
            {
                WinLoss = 450,
                Turnover = 750,
                BetCount = 8
            };

            // Act
            var sumObject = firstObject + secondObject;

            // Assert
            Assert.That(sumObject, IsDeeplyEqual.To(expectedObject));
        }
    }
}
