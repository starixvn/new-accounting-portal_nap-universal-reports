using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.AssociatedAccount.Model
{
    public class AssociatedAccountModelUnitTests
    {
        [Test]
        public void OperatorPlus_TwoAssociatedAccountModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new AssociatedAccountModel
            {
                Username = "User 1",
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };

            var secondObject = new AssociatedAccountModel
            {
                Username = "User 2",
                WinLoss = 200,
                Turnover = 300,
                BetCount = 3
            };

            var expectedObject = new AssociatedAccountModel
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
