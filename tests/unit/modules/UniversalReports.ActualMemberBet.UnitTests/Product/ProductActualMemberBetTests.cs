using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.ActualMemberBet.Product;

namespace UniversalReports.ActualMemberBet.UnitTests.Product
{
    [TestFixture]
    public class ProductActualMemberBetTests
    {
        [Test]
        public void OperatorPlus_TwoProductActualMemberBet_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new ProductActualMemberBet
            {
                ProductName = "Soccer Major",
                KeyId = "Any key 1",
                BetCount = 2,
                MemberTurnoverRM = 100,
                MemberNetWinLoss = 20,
                HouseRealTurnover = 80,
                HouseVirtualTurnover = 120,
                HouseRealIncome = 80,
                HouseVirtualWinLoss = 50
            };

            var secondObject = new ProductActualMemberBet
            {
                ProductName = "Soccer Minor",
                KeyId = "Any key 2",
                BetCount = 3,
                MemberTurnoverRM = 150,
                MemberNetWinLoss = 50,
                HouseRealTurnover = 100,
                HouseVirtualTurnover = 180,
                HouseRealIncome = 120,
                HouseVirtualWinLoss = 80
            };

            var expectedObject = new ProductActualMemberBet
            {
                ProductName = "Grand Total",
                KeyId = string.Empty,
                BetCount = 5,
                MemberTurnoverRM = 250,
                MemberNetWinLoss = 70,
                HouseRealTurnover = 180,
                HouseVirtualTurnover = 300,
                HouseRealIncome = 200,
                HouseVirtualWinLoss = 130
            };

            // Act
            var sumObject = firstObject + secondObject;

            // Assert
            Assert.That(sumObject, IsDeeplyEqual.To(expectedObject));
        }
    }
}
