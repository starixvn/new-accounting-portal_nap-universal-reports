using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.BetTypeGroup.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.BetTypeGroup.Model
{
    public class BetTypeGroupModelUnitTests
    {
        [Test]
        public void OperatorPlus_TwoBetTypeGroupModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new BetTypeGroupModel
            {
                BettypeGroupId = 1,
                BettypeGroupName = "Bettype Group 1",
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };

            var secondObject = new BetTypeGroupModel
            {
                BettypeGroupId = 2,
                BettypeGroupName = "Bettype Group 2",
                WinLoss = 200,
                Turnover = 300,
                BetCount = 3
            };

            var expectedObject = new BetTypeGroupModel
            {
                BettypeGroupId = 0,
                BettypeGroupName = string.Empty,
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