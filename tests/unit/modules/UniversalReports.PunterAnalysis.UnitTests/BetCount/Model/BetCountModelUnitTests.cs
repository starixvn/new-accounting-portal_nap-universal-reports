using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using UniversalReports.PunterAnalysis.BetCount.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.BetCount.Model
{
    public class BetCountModelUnitTests
    {
        [Test]
        public void OperatorPlus_TwoBetCountModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new BetCountModel
            {
                Date = DateTime.Today.ToShortDateString(),
                BetCount = 3,
                WinCount = 2,
                DrawCount = 1,
                WinLoss = 100
            };

            var secondObject = new BetCountModel
            {
                Date = DateTime.Today.AddDays(-1).ToShortDateString(),
                BetCount = 5,
                WinCount = 3,
                DrawCount = 2,
                WinLoss = 200
            };

            var expectedObject = new BetCountModel
            {
                Date = DateTime.MinValue.ToShortDateString(),
                BetCount = 8,
                WinCount = 5,
                DrawCount = 3,
                WinLoss = 300
            };

            // Act
            var sumObject = firstObject + secondObject;

            // Assert
            Assert.That(sumObject, IsDeeplyEqual.To(expectedObject));
        }
    }
}
