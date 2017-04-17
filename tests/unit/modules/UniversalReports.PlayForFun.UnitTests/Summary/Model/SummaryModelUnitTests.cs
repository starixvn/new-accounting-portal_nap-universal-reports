using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.UnitTests.Summary.Model
{
    public class SummaryModelUnitTests
    {
        [Test]
        public void OperatorPlus_TwoSummaryModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new SummaryModel
            {
                Username = "User 1",
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };

            var secondObject = new SummaryModel
            {
                Username = "User 2",
                WinLoss = 200,
                Turnover = 300,
                BetCount = 3
            };

            var expectedObject = new SummaryModel
            {
                Username = string.Empty,
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
