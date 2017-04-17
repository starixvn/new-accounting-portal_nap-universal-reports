using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.UnitTests.Detail.Model
{
    public class DetailModelUnitTests
    {
        [Test]
        public void OperatorPlus_TwoDetailModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new DetailModel
            {
                Username = "User 1",
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };

            var secondObject = new DetailModel
            {
                Username = "User 2",
                WinLoss = 200,
                Turnover = 300,
                BetCount = 3
            };

            var expectedObject = new DetailModel
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
