using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.SBPerformance.Main;

namespace UniversalReports.SBPerformance.UnitTests.Main
{
    [TestFixture]
    [Category("SBPerformance")]
    public class EntityTests
    {
        [Test]
        public void OperatorPlus_TwoEntities_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new Entity { Id = 1, Name = "Name 1", BetCount = 10, RealIncome = 10, RealTurnover = 20 };

            var secondObject = new Entity { Id = 2, Name = "Name 2", BetCount = 5, RealIncome = 5, RealTurnover = 10 };

            var expectedObject = new Entity
            {
                Id = 0,
                Name = "Total",
                BetCount = 15,
                RealIncome = 15,
                RealTurnover = 30
            };

            // Act
            var sumObject = firstObject + secondObject;

            // Assert
            Assert.That(sumObject, IsDeeplyEqual.To(expectedObject));
        }
    }
}