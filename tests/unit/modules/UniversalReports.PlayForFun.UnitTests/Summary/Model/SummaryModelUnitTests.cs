using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
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
                Date = DateTime.Today.AddDays(-1),
                PlayerCount = 1,
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };

            var secondObject = new SummaryModel
            {
                Date = DateTime.Today,
                PlayerCount = 5,
                WinLoss = 200,
                Turnover = 300,
                BetCount = 3
            };

            var expectedObject = new SummaryModel
            {
                Date = DateTime.MinValue,
                PlayerCount = 6,
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
